using Microsoft.EntityFrameworkCore;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using Sge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Repositories
{
    public class UsuarioDocumentoRepository : RepositoryBase<UsuarioDocumento>, IUsuarioDocumentoRepository
    {
        public UsuarioDocumentoRepository(SgeContext _context) : base(_context)
        { }

        //public async Task<IEnumerable<UsuarioDocumento>> GetUsuarioPagamentosAsync(int usuarioId)
        //{
        //    return await _context.UsuarioDocumentos
        //        .Where(_ => _.DocumentoId == (int)EDocumento.Pagamento && _.UsuarioId == usuarioId && _.Excluido == false)
        //        .Include(_ => _.Status)
        //        .Include(_=> _.Documento)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<UsuarioDocumento>> GetUsuarioDocumentosAsync(int usuarioId, int? documentoId)
        {
            IQueryable<UsuarioDocumento> query = _context.UsuarioDocumentos
                .Where(_ => _.UsuarioId == usuarioId && _.Excluido == false)
                .Include(_ => _.Status)
                .Include(_ => _.Documento);

            if(documentoId != null)
            {
                query = query.Where(_ => _.DocumentoId == documentoId);
            }

            return await query.ToListAsync();
        }

        public async Task<UsuarioDocumento> GetUsuarioAtestadoAsync(int usuarioId)
        {
            return await _context.UsuarioDocumentos
                .Where(_ => _.DocumentoId == (int)EDocumento.Atestado && _.UsuarioId == usuarioId && _.Excluido == false)
                .Include(_ => _.Status)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalDocumentosAsync(int documentoId, int statusId)
        {
            var count = await _context.UsuarioDocumentos
                .Where(_=>_.Excluido == false && _.StatusId == statusId && _.DocumentoId == documentoId)
                .CountAsync();
            return count;
        }

        public async Task<int> GetTotalDocumentosAsync(int statusId)
        {
            var count = await _context.UsuarioDocumentos
                .Where(_ => _.Excluido == false && _.StatusId == statusId)
                .CountAsync();
            return count;
        }

        public async Task<List<UsuarioDocumento>> GetDocumentosByUnidadeAsync(int documentoId, int statusId, int unidadeId)
        {
            return await _context.UsuarioDocumentos
                .Include(_ => _.Status)
                .Include(_=>_.Documento)
                .Where(_ => _.DocumentoId == documentoId && _.Excluido == false && _.StatusId == statusId && _.Usuario.UnidadeId == unidadeId)
                .ToListAsync();
        }

        public async Task<List<UsuarioDocumento>> GetDocumentosByStatusAsync(int documentoId, int statusId)
        {
            var result = await _context.UsuarioDocumentos
                .Include(_ => _.Status)
                .Include(_ => _.Documento)
                .Include(_ => _.Usuario).ThenInclude(_=> _.Unidade)
                .Where(_ => _.DocumentoId == documentoId && _.Excluido == false && _.StatusId == statusId)
                .ToListAsync();
            return result;
        }
    }
}
