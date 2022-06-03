using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IDocumentoService
    {
        Task<IEnumerable<Documento>> GetAllAsync();
        Task<Documento> GetAsync(int id);
        void Add(Documento entity);
        void Update(Documento entity);
        void Delete(Documento entity);
        Task<bool> SaveChangesAsync();
    }
}
