using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso> GetAsync(int id);
        void Add(Curso entity);
        void Update(Curso entity);
        void Delete(Curso entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Curso>> GetAllByUnidadeAsync(int unidadeId);
    }
}
