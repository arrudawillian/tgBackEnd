using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IUnidadeService
    {
        Task<IEnumerable<Unidade>> GetAllAsync();
        Task<Unidade> GetAsync(int id);
        void Add(Unidade entity);
        void Update(Unidade entity);
        void Delete(Unidade entity);
        Task<bool> SaveChangesAsync();
    }
}
