using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Data.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario[]> GetAllDetalhesAsync();
        Task<Usuario> GetDetalhesAsync(int id);
        Task<Usuario> GetLoginAsync(string email);
        Task<int> GetTotalUsuariosAsync();
        Task<dynamic> GetTotalPacotesAsync();
        Task<Usuario> GetDetalhesByCodigoAsync(string codigo);
        Task<List<Usuario>> GetCheckin();
        Task<Usuario> GetByCodigoAsync(string codigo);

    }
}
