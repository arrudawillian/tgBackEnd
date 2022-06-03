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
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SgeContext _context) : base(_context)
        { }

        public async Task<Usuario[]> GetAllDetalhesAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(_ => _.Unidade)
                .Include(_ => _.Curso)
                .Include(_ => _.UnidadePacote)
                .ThenInclude(_ => _.Pacote);

            query = query.OrderBy(_ => _.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario> GetDetalhesAsync(int id)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Where(_ => _.Id == id)
                .Include(_ => _.Unidade)
                .Include(_ => _.Curso)
                .Include(_ => _.UnidadePacote)
                .ThenInclude(_ => _.Pacote);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetLoginAsync(string email)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Where(_ => _.Email == email);
                
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalUsuariosAsync()
        {
            var count = await _context.Usuarios.CountAsync();
            return count;
        }

        public async Task<dynamic> GetTotalPacotesAsync()
        {

            var completos = await _context.Usuarios
                .Include(_ => _.UnidadePacote)
                .Where(_ => _.UnidadePacote.PacoteId == 1)
                .CountAsync();

            var atletas = await _context.Usuarios
                .Include(_ => _.UnidadePacote)
                .Where(_ => _.UnidadePacote.PacoteId == 2)
                .CountAsync();

            return new { Atletas = atletas, Completos = completos};
        }

        public async Task<Usuario> GetDetalhesByCodigoAsync(string codigo)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Where(_=>_.Codigo == codigo)
                .Include(_ => _.Unidade)
                .Include(_ => _.Curso)
                .Include(_ => _.UnidadePacote)
                .ThenInclude(_ => _.Pacote);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetCheckin()
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Include(_ => _.Unidade)
                .Include(_ => _.Curso)
                .Include(_ => _.UnidadePacote)
                .ThenInclude(_ => _.Pacote)
                .Include(_ => _.UsuarioDocumentos)
                .Include(_ => _.Pagamentos)
                .Where(_=>_.PerfilId == (int)EPerfil.Usuario)
                .Where(_=>_.UnidadePacoteId != null)
                .Where(_=>_.UsuarioDocumentos.Any(_=>_.DocumentoId == (int)EDocumento.Atestado && _.Excluido==false && _.StatusId == (int)EStatus.Aprovado))
                .Where(_=>_.Codigo == null)
                .Where(_=>_.Pagamentos.Sum(_=>_.Valor) >= _.UnidadePacote.Valor);

                return await query.ToListAsync();

        }

        public async Task<Usuario> GetByCodigoAsync(string codigo)
        {
            IQueryable<Usuario> query = _context.Usuarios
                .Where(_ => _.Codigo == codigo);

            return await query.FirstOrDefaultAsync();
        }
    }
}
