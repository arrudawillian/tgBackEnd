using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using Sge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class UsuarioDocumentoService : IUsuarioDocumentoService
    {
        private readonly IUsuarioDocumentoRepository _usuarioDocumentoRepository;

        public UsuarioDocumentoService(IUsuarioDocumentoRepository usuarioDocumentoRepository)
        {
            _usuarioDocumentoRepository = usuarioDocumentoRepository;
        }

        public void Add(UsuarioDocumento entity)
        {
            _usuarioDocumentoRepository.Add(entity);
        }

        public void Delete(UsuarioDocumento entity)
        {
            _usuarioDocumentoRepository.Delete(entity);
        }

        public async Task<UsuarioDocumento> GetAsync(int id)
        {
            return await _usuarioDocumentoRepository.GetAsync(id);
        }

        public async Task<IEnumerable<UsuarioDocumento>> GetAllAsync()
        {
            return await _usuarioDocumentoRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _usuarioDocumentoRepository.SaveChangesAsync();
        }

        public void Update(UsuarioDocumento entity)
        {
            _usuarioDocumentoRepository.Update(entity);
        }

        public async Task<IEnumerable<UsuarioDocumento>> GetUsuarioPagamentosAsync(int usuarioId)
        {
            return await _usuarioDocumentoRepository.GetUsuarioDocumentosAsync(usuarioId, (int)EDocumento.Pagamento);
        }

        public async Task<IEnumerable<UsuarioDocumento>> GetUsuarioDocumentosAsync(int usuarioId)
        {
            return await _usuarioDocumentoRepository.GetUsuarioDocumentosAsync(usuarioId,null);
        }

        public async Task<IEnumerable<UsuarioDocumento>> GetUsuarioAtestadosAsync(int usuarioId)
        {
            return await _usuarioDocumentoRepository.GetUsuarioDocumentosAsync(usuarioId, (int)EDocumento.Atestado);
        }

        public async Task<UsuarioDocumento> GetUsuarioAtestadoAsync(int usuarioId)
        {
            return await _usuarioDocumentoRepository.GetUsuarioAtestadoAsync(usuarioId);
        }

        public async Task<int> GetTotalDocumentosAsync(int documentoId, int statusId)
        {
            return await _usuarioDocumentoRepository.GetTotalDocumentosAsync(documentoId, statusId);
        }

        public async Task<int> GetTotalDocumentosAsync(int statusId)
        {
            return await _usuarioDocumentoRepository.GetTotalDocumentosAsync(statusId);
        }

        public async Task<List<UsuarioDocumento>> GetDocumentosByUnidadeAsync(int documentoId, int statusId, int unidadeId)
        {
            return await _usuarioDocumentoRepository.GetDocumentosByUnidadeAsync(documentoId, statusId, unidadeId);
        }

        public async Task<List<UsuarioDocumento>> GetDocumentosByStatusAsync(int documentoId, int statusId)
        {
            var result = await _usuarioDocumentoRepository.GetDocumentosByStatusAsync(documentoId, statusId);
            return result;
        }
    }
}
