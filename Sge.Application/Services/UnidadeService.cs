using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public void Add(Unidade entity)
        {
            _unidadeRepository.Add(entity);
        }

        public void Delete(Unidade entity)
        {
            _unidadeRepository.Delete(entity);
        }

        public async Task<Unidade> GetAsync(int id)
        {
           return await _unidadeRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Unidade>> GetAllAsync()
        {
            return await _unidadeRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _unidadeRepository.SaveChangesAsync();
        }

        public void Update(Unidade entity)
        {
            _unidadeRepository.Update(entity);
        }
    }
}
