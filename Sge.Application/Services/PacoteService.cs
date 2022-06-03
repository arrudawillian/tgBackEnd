using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class PacoteService : IPacoteService
    {
        private readonly IPacoteRepository _pacoteRepository;

        public PacoteService(IPacoteRepository pacoteRepository)
        {
            _pacoteRepository = pacoteRepository;
        }

        public void Add(Pacote entity)
        {
            _pacoteRepository.Add(entity);
        }

        public void Delete(Pacote entity)
        {
            _pacoteRepository.Delete(entity);
        }

        public async Task<Pacote> GetAsync(int id)
        {
           return await _pacoteRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Pacote>> GetAllAsync()
        {
            return await _pacoteRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _pacoteRepository.SaveChangesAsync();
        }

        public void Update(Pacote entity)
        {
            _pacoteRepository.Update(entity);
        }
    }
}
