using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status> GetAsync(int id);
        void Add(Status entity);
        void Update(Status entity);
        void Delete(Status entity);
        Task<bool> SaveChangesAsync();
    }
}
