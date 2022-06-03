using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IUnidadePacoteService
    {
        Task<IEnumerable<UnidadePacote>> GetAllAsync();
        Task<UnidadePacote> GetAsync(int id);
        void Add(UnidadePacote entity);
        void Update(UnidadePacote entity);
        void Delete(UnidadePacote entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<UnidadePacote>> GetUnidadePacotesAsync(int unidadeId);
    }
}
