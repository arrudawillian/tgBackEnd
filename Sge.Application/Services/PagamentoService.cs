using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public void Add(Pagamento entity)
        {
            _pagamentoRepository.Add(entity);
        }

        public void Delete(Pagamento entity)
        {
            _pagamentoRepository.Delete(entity);
        }

        public async Task<Pagamento> GetAsync(int id)
        {
           return await _pagamentoRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            return await _pagamentoRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _pagamentoRepository.SaveChangesAsync();
        }

        public void Update(Pagamento entity)
        {
            _pagamentoRepository.Update(entity);
        }

        public async Task<decimal> GetFaltaPagarAsync(int usuarioId)
        {
            return await _pagamentoRepository.GetFaltaPagarAsync(usuarioId);
        }

        public async Task<dynamic> GetTotalPagamentosAsync()
        {
            return await _pagamentoRepository.GetTotalPagamentosAsync();
        }
    }
}
