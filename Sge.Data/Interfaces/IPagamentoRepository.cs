using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Interfaces
{
    public interface IPagamentoRepository : IRepositoryBase<Pagamento>
    {
        Task<decimal> GetFaltaPagarAsync(int usuarioId);
        Task<dynamic> GetTotalPagamentosAsync();
    }
}
