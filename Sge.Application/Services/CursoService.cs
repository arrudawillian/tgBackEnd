using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Add(Curso entity)
        {
            _cursoRepository.Add(entity);
        }

        public void Delete(Curso entity)
        {
            _cursoRepository.Delete(entity);
        }

        public async Task<Curso> GetAsync(int id)
        {
           return await _cursoRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _cursoRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _cursoRepository.SaveChangesAsync();
        }

        public void Update(Curso entity)
        {
            _cursoRepository.Update(entity);
        }

        public async Task<IEnumerable<Curso>> GetAllByUnidadeAsync(int unidadeId)
        {
            return await _cursoRepository.GetAllByUnidadeAsync(unidadeId);
        }
    }
}
