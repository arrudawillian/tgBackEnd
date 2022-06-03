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
    public class UnidadePacoteRepository : RepositoryBase<UnidadePacote>, IUnidadePacoteRepository
    {
        public UnidadePacoteRepository(SgeContext _context) : base(_context)
        { }

        public async Task<IEnumerable<UnidadePacote>> GetUnidadePacotesAsync(int unidadeId)
        {
            return await _context.UnidadePacotes
                .Where(_=>_.UnidadeId == unidadeId)
                .Include(_=>_.Pacote)
                .ToListAsync();
        }
    }
}
