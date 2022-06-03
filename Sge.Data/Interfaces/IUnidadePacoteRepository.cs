using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Interfaces
{
    public interface IUnidadePacoteRepository : IRepositoryBase<UnidadePacote>
    {
        Task<IEnumerable<UnidadePacote>> GetUnidadePacotesAsync(int unidadeId);
    }
}
