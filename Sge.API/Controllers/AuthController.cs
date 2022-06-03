using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sge.Application.Dtos;
using Sge.Application.Interfaces;
using Sge.Domain.Entities;
using Sge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AuthController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registro")]
        public async Task<IActionResult> PostRegistroAsync(UsuarioRegistroDto usuarioRegistroDto)
        {
            try
            {

                var usuario = _mapper.Map<Usuario>(usuarioRegistroDto);
                usuario.PerfilId = (int)EPerfil.Usuario;
                _usuarioService.Add(usuario);
                if (await _usuarioService.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuario.Id}", _mapper.Map<UsuarioDto>(usuario));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("UK_Email"))
                {
                    return BadRequest("Email Duplicado.");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> PostLoginAsync(UsuarioLoginDto usuarioLoginDto)
        {
            try
            {

                var usuario = _mapper.Map<Usuario>(usuarioLoginDto);
                var result = await _usuarioService.GetLoginAsync(usuario);
                if (result != null)
                {
                    return Ok(new
                    {
                        token = result.PerfilId,
                        usuario = _mapper.Map<UsuarioDto>(result)
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }
    }
}
