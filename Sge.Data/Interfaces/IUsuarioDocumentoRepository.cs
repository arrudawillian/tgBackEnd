using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Interfaces
{
    public interface IUsuarioDocumentoRepository : IRepositoryBase<UsuarioDocumento>
    {
        Task<IEnumerable<UsuarioDocumento>> GetUsuarioDocumentosAsync(int usuarioId, int? documentoId);
        Task<UsuarioDocumento> GetUsuarioAtestadoAsync(int usuarioId);
        Task<int> GetTotalDocumentosAsync(int documentoId, int statusId);
        Task<int> GetTotalDocumentosAsync(int statusId);
        Task<List<UsuarioDocumento>> GetDocumentosByUnidadeAsync(int documentoId, int statusId, int unidadeId);
        Task<List<UsuarioDocumento>> GetDocumentosByStatusAsync(int documentoId, int statusId);
    }
}
