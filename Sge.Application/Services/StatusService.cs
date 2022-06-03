using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public void Add(Status entity)
        {
            _statusRepository.Add(entity);
        }

        public void Delete(Status entity)
        {
            _statusRepository.Delete(entity);
        }

        public async Task<Status> GetAsync(int id)
        {
           return await _statusRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return await _statusRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _statusRepository.SaveChangesAsync();
        }

        public void Update(Status entity)
        {
            _statusRepository.Update(entity);
        }
    }
}
