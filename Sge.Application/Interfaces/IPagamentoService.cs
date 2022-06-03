using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<Pagamento> GetAsync(int id);
        void Add(Pagamento entity);
        void Update(Pagamento entity);
        void Delete(Pagamento entity);
        Task<bool> SaveChangesAsync();
        Task<decimal> GetFaltaPagarAsync(int usuarioId);
        Task<dynamic> GetTotalPagamentosAsync();
    }
}
