using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Interfaces
{
    public interface ICursoRepository : IRepositoryBase<Curso>
    {
        Task<IEnumerable<Curso>> GetAllByUnidadeAsync(int unidadeId);
    }
}
