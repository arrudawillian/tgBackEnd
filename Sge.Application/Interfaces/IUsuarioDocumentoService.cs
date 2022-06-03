using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IUsuarioDocumentoService
    {
        Task<IEnumerable<UsuarioDocumento>> GetAllAsync();
        Task<UsuarioDocumento> GetAsync(int id);
        void Add(UsuarioDocumento entity);
        void Update(UsuarioDocumento entity);
        void Delete(UsuarioDocumento entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<UsuarioDocumento>> GetUsuarioPagamentosAsync(int usuarioId);
        Task<IEnumerable<UsuarioDocumento>> GetUsuarioDocumentosAsync(int usuarioId);
        Task<IEnumerable<UsuarioDocumento>> GetUsuarioAtestadosAsync(int usuarioId);
        Task<UsuarioDocumento> GetUsuarioAtestadoAsync(int usuarioId);
        Task<int> GetTotalDocumentosAsync(int documentoId, int statusId);
        Task<int> GetTotalDocumentosAsync(int statusId);
        Task<List<UsuarioDocumento>> GetDocumentosByUnidadeAsync(int documentoId, int statusId, int unidadeId);
        Task<List<UsuarioDocumento>> GetDocumentosByStatusAsync(int documentoId, int statusId);
    }
}
