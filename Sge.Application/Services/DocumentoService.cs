using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public void Add(Documento entity)
        {
            _documentoRepository.Add(entity);
        }

        public void Delete(Documento entity)
        {
            _documentoRepository.Delete(entity);
        }

        public async Task<Documento> GetAsync(int id)
        {
           return await _documentoRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Documento>> GetAllAsync()
        {
            return await _documentoRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _documentoRepository.SaveChangesAsync();
        }

        public void Update(Documento entity)
        {
            _documentoRepository.Update(entity);
        }
    }
}
