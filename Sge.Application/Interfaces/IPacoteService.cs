using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IPacoteService
    {
        Task<IEnumerable<Pacote>> GetAllAsync();
        Task<Pacote> GetAsync(int id);
        void Add(Pacote entity);
        void Update(Pacote entity);
        void Delete(Pacote entity);
        Task<bool> SaveChangesAsync();
    }
}
