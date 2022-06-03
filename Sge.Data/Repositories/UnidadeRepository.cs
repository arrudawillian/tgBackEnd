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
    public class UnidadeRepository : RepositoryBase<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(SgeContext _context) : base(_context)
        { }

        public override async Task<IEnumerable<Unidade>> GetAllAsync()
        {
            return await _context.Unidades.OrderBy(_ => _.Nome).ToListAsync();
        }

    }
}
