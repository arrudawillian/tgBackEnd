using Microsoft.EntityFrameworkCore;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Repositories
{
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(SgeContext _context) : base(_context)
        { }

        public async Task<decimal> GetFaltaPagarAsync(int usuarioId)
        {

            var valorPacote = await _context.Usuarios
                .Where(_ => _.Id == usuarioId)
                .Include(_ => _.UnidadePacote)
                .Select(_ => _.UnidadePacote.Valor).FirstOrDefaultAsync();

            var totalPago = await _context.Pagamentos
                .Where(_ => _.UsuarioId == usuarioId)
                .SumAsync(_ => _.Valor);

            var result = valorPacote - totalPago;

            return result;
        }

        public async Task<dynamic> GetTotalPagamentosAsync()
        {
            var valorPacote = await _context.Usuarios
                .Include(_ => _.UnidadePacote)
                .SumAsync(_ => _.UnidadePacote.Valor);

            var totalPago = await _context.Pagamentos
                .SumAsync(_ => _.Valor);

            var result = valorPacote - totalPago;



            return new { TotalPago = totalPago, FaltaPagar = result };
        }
    }
}
