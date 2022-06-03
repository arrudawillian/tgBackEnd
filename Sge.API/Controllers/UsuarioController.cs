using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sge.Application.Dtos;
using Sge.Application.Interfaces;
using Sge.Domain.Entities;
using Sge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioService usuarioService,
            IMapper mapper
            )
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllAsync();
                return Ok(_mapper.Map<UsuarioDto[]>(usuarios));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> GetAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioService.GetAsync(usuarioId);
                return Ok(_mapper.Map<UsuarioDto>(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPut]
        [Route("registro/{usuarioId}")]
        public async Task<IActionResult> PutRegistroAsync(int usuarioId, UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.GetAsync(usuarioId);
                if (usuario == null)
                    return BadRequest();

                _mapper.Map(usuarioDto, usuario);

                _usuarioService.Update(usuario);
                if (await _usuarioService.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuario.Id}", usuario);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{usuarioId}")]
        public async Task<IActionResult> PutAsync(int usuarioId, UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = await _usuarioService.GetAsync(usuarioId);
                if (usuario == null)
                    return BadRequest();

                if(usuarioDto.Img != null)
                {
                    var img = usuarioDto.Img.Split("/");
                    if(img[0] != "files")
                    {
                        if (usuarioDto.Img != usuario.Img)
                        {
                            var folderName = Path.Combine("Resources", "Images");
                            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                            usuarioDto.Img = Path.Combine(folderName, usuarioDto.Img);
                        }
                    }
                }

                if(usuarioDto.Codigo != usuario.Codigo)
                {
                    var codigo = await _usuarioService.GetByCodigoAsync(usuarioDto.Codigo);
                    if (codigo != null)
                    {
                        return BadRequest("Código já cadastrado");
                    }
                }

                

                _mapper.Map(usuarioDto, usuario);


                _usuarioService.Update(usuario);
                if (await _usuarioService.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuario.Id}", usuario);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("detalhes")]
        public async Task<IActionResult> GetAllDetalhesAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllDetalhesAsync();
                return Ok(_mapper.Map<List<UsuarioDetalheDto>>(usuarios));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("detalhes/{usuarioId}")]
        public async Task<IActionResult> GetDetalhesAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioService.GetDetalhesAsync(usuarioId);
                return Ok(_mapper.Map<UsuarioDetalheDto>(usuario));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("inscricoes")]
        public async Task<IActionResult> GetTotalInscricoes()
        {
            try
            {
                var total = await _usuarioService.GetTotalUsuariosAsync();
                return Ok(total);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("pacotes")]
        public async Task<IActionResult> GetTotalPacotes()
        {
            try
            {
                var pacotes = await _usuarioService.GetTotalPacotesAsync();
                return Ok(pacotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("detalhesByCodigo/{codigo}")]
        public async Task<IActionResult> GetDetalhesByCodigoAsync(string codigo)
        {
            try
            {
                var usuario = await _usuarioService.GetDetalhesByCodigoAsync(codigo);
                return Ok(_mapper.Map<UsuarioDetalheDto>(usuario));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("checkin")]
        public async Task<IActionResult> GetCheckinAsync()
        {
            try
            {
                var usuarios = await _usuarioService.GetCheckin();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

    }
}
