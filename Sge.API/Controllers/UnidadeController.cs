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
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeService _unidadeService;
        private readonly IUnidadePacoteService _unidadePacoteService;

        public UnidadeController(IUnidadeService unidadeService, IUnidadePacoteService unidadePacoteService)
        {
            _unidadeService = unidadeService;
            _unidadePacoteService = unidadePacoteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var unidades = await _unidadeService.GetAllAsync();
                return Ok(unidades);
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
                var unidades = await _unidadeService.GetAsync(id);
                return Ok(unidades);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("unidadePacotes/{id}")]
        public async Task<IActionResult> GetUnidadePacotesAsync(int id)
        {
            try
            {
                var unidadePacotes = await _unidadePacoteService.GetUnidadePacotesAsync(id);
                return Ok(unidadePacotes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUnidadeAsync(Unidade unidade)
        {
            try
            {
                _unidadeService.Add(unidade);
                if (await _unidadeService.SaveChangesAsync())
                {
                    return Created($"/unidade/{unidade.Id}", unidade);
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
        [Route("{unidadeId}")]
        public async Task<IActionResult> Delete(int unidadeId)
        {
            try
            {
                var unidadeOld = await _unidadeService.GetAsync(unidadeId);

                if (unidadeOld == null) return BadRequest();

                _unidadeService.Delete(unidadeOld);
                if (await _unidadeService.SaveChangesAsync())
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
