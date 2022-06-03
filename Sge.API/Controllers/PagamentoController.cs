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
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(
            IPagamentoService PagamentoService
            )
        {
            _pagamentoService = PagamentoService;
        }       

        [HttpGet]
        [Route("faltaPagar/{usuarioId}")]
        public async Task<IActionResult> GetFaltaPagarAsync(int usuarioId)
        {
            try
            {
                var pago = await _pagamentoService.GetFaltaPagarAsync(usuarioId);
                return Ok(pago);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("totalPagamentos")]
        public async Task<IActionResult> GetTotalPagamentosAsync()
        {
            try
            {
                return Ok(await _pagamentoService.GetTotalPagamentosAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPagamento(Pagamento pagamento)
        {
            try
            {
                _pagamentoService.Add(pagamento);

                if (await _pagamentoService.SaveChangesAsync())
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
