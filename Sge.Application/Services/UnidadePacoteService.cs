using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class UnidadePacoteService : IUnidadePacoteService
    {
        private readonly IUnidadePacoteRepository _unidadePacoteRepository;

        public UnidadePacoteService(IUnidadePacoteRepository unidadePacoteRepository)
        {
            _unidadePacoteRepository = unidadePacoteRepository;
        }

        public void Add(UnidadePacote entity)
        {
            _unidadePacoteRepository.Add(entity);
        }

        public void Delete(UnidadePacote entity)
        {
            _unidadePacoteRepository.Delete(entity);
        }

        public async Task<UnidadePacote> GetAsync(int id)
        {
           return await _unidadePacoteRepository.GetAsync(id);
        }

        public async Task<IEnumerable<UnidadePacote>> GetAllAsync()
        {
            return await _unidadePacoteRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _unidadePacoteRepository.SaveChangesAsync();
        }

        public void Update(UnidadePacote entity)
        {
            _unidadePacoteRepository.Update(entity);
        }

        public async Task<IEnumerable<UnidadePacote>> GetUnidadePacotesAsync(int unidadeId)
        {
            return await _unidadePacoteRepository.GetUnidadePacotesAsync(unidadeId);
        }
    }
}
