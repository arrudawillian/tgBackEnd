using Microsoft.EntityFrameworkCore;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Repositories
{
    public class CursoRepository : RepositoryBase<Curso>, ICursoRepository
    {
        public CursoRepository(SgeContext _context) : base(_context)
        { }

        public override async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos.Include(_ => _.Unidade).OrderBy(_ => _.Unidade.Nome).ThenBy(_=>_.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Curso>> GetAllByUnidadeAsync(int unidadeId)
        {
            return await _context.Cursos.Where(_ => _.UnidadeId == unidadeId).OrderBy(_ => _.Nome).ToListAsync();
        }
    }
}
