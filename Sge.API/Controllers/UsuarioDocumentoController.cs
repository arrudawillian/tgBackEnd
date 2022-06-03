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
    public class UsuarioDocumentoController : ControllerBase
    {
        private readonly IUsuarioDocumentoService _usuarioDocumentoService;
        private readonly IMapper _mapper;

        public UsuarioDocumentoController(
            IUsuarioDocumentoService usuarioDocumentoService,
            IMapper mapper
            )
        {
            _usuarioDocumentoService = usuarioDocumentoService;
            _mapper = mapper;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, filename);
                    var dbPath = Path.Combine(folderName, filename);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //UsuarioDocumento usuarioDocumento = new UsuarioDocumento
                    //{
                    //    Path = dbPath,
                    //    StatusId = (int)EStatus.Pendente,
                    //    UsuarioId = 1,
                    //    Titulo = filename,
                    //    DocumentoId = 1
                    //};

                    //_usuarioDocumentoService.Add(usuarioDocumento);
                    //if (await _usuarioDocumentoService.SaveChangesAsync())
                    //{
                    return Ok();
                    //}
                    //else
                    //{
                    //    return BadRequest();
                    //}
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> GetUsuarioDocumentosAsync(int usuarioId)
        {
            try
            {
                var documentos = await _usuarioDocumentoService.GetUsuarioDocumentosAsync(usuarioId);
                return Ok(documentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("atestados/{usuarioId}")]
        public async Task<IActionResult> GetUsuarioAtestadosAsync(int usuarioId)
        {
            try
            {
                var atestados = await _usuarioDocumentoService.GetUsuarioAtestadosAsync(usuarioId);
                return Ok(atestados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("atestado/{usuarioId}")]
        public async Task<IActionResult> GetUsuarioAtestadoAsync(int usuarioId)
        {
            try
            {
                var atestado = await _usuarioDocumentoService.GetUsuarioAtestadoAsync(usuarioId);
                return Ok(atestado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("pagamentos/{usuarioId}")]
        public async Task<IActionResult> GetUsuarioPagamentosAsync(int usuarioId)
        {
            try
            {
                var pagamentos = await _usuarioDocumentoService.GetUsuarioPagamentosAsync(usuarioId);
                return Ok(pagamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuarioDocumentoAsync(UsuarioDocumento usuarioDocumento)
        {
            try
            {
                if (usuarioDocumento.Path == null)
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    usuarioDocumento.Path = Path.Combine(folderName, usuarioDocumento.Titulo);
                }

                _usuarioDocumentoService.Add(usuarioDocumento);
                if (await _usuarioDocumentoService.SaveChangesAsync())
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

        [HttpDelete]
        [Route("{documentoId}")]
        public async Task<IActionResult> Delete(int documentoId)
        {
            try
            {
                var documento = await _usuarioDocumentoService.GetAsync(documentoId);

                if (documento == null) return BadRequest();

                documento.Excluido = true;

                _usuarioDocumentoService.Update(documento);
                if (await _usuarioDocumentoService.SaveChangesAsync())
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

        [HttpGet]
        [Route("totalDocumentos/{documentoId}/{statusId}")]
        public async Task<IActionResult> GetTotalDocumentos(int documentoId, int statusId)
        {
            try
            {
                return Ok(await _usuarioDocumentoService.GetTotalDocumentosAsync(documentoId, statusId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("totalDocumentos/{statusId}")]
        public async Task<IActionResult> GetTotalDocumentos(int statusId)
        {
            try
            {
                return Ok(await _usuarioDocumentoService.GetTotalDocumentosAsync(statusId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("documentosByUnidade/{documentoId}/{statusId}/{unidadeId}")]
        public async Task<IActionResult> GetDocumentosByUnidade(int documentoId, int statusId, int unidadeId)
        {
            try
            {
                return Ok(await _usuarioDocumentoService.GetDocumentosByUnidadeAsync(documentoId, statusId, unidadeId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutUsuarioDocumentoAsync(UsuarioDocumentoPutDto usuarioDocumentoPutDto)
        {
            try
            {
                var oldUsuarioDocumento = await _usuarioDocumentoService.GetAsync(usuarioDocumentoPutDto.Id);
                if (oldUsuarioDocumento == null)
                    return BadRequest();

                var usuarioDocumento = _mapper.Map<UsuarioDocumento>(usuarioDocumentoPutDto);


                _mapper.Map(usuarioDocumento, oldUsuarioDocumento);

                _usuarioDocumentoService.Update(usuarioDocumento);
                if (await _usuarioDocumentoService.SaveChangesAsync())
                {
                    return Created($"/usuario/{usuarioDocumento.Id}", usuarioDocumento);
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
        [Route("documentosByStatus/{documentoId}/{statusId}")]
        public async Task<IActionResult> GetDocumentosByStatus(int documentoId, int statusId)
        {
            try
            {
                var documentos = await _usuarioDocumentoService.GetDocumentosByStatusAsync(documentoId, statusId);
                var result = _mapper.Map<UsuarioDocumentoDto[]>(documentos);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }
    }

    
}
