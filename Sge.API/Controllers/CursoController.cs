using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sge.Application.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var cursos = await _cursoService.GetAllAsync();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var curso = await _cursoService.GetAsync(id);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("unidade/{unidadeId}")]
        public async Task<IActionResult> GetAllByUnidadeAsync(int unidadeId)
        {
            try
            {
                var curso = await _cursoService.GetAllByUnidadeAsync(unidadeId);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCursoAsync(Curso curso)
        {
            try
            {
                _cursoService.Add(curso);
                if (await _cursoService.SaveChangesAsync())
                {
                    return Created($"/curso/{curso.Id}", curso);
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

        [HttpDelete]
        [Route("{cursoId}")]
        public async Task<IActionResult> Delete(int cursoId)
        {
            try
            {
                var cursoOld = await _cursoService.GetAsync(cursoId);

                if (cursoOld == null) return BadRequest();

                _cursoService.Delete(cursoOld);
                if (await _cursoService.SaveChangesAsync())
                {
                    return Ok();
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
    }
}
