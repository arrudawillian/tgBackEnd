using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetAsync(int id);
        void Add(Usuario entity);
        void Update(Usuario entity);
        void Delete(Usuario entity);
        Task<bool> SaveChangesAsync();

        Task<Usuario[]> GetAllDetalhesAsync();
        Task<Usuario> GetDetalhesAsync(int id);
        Task<Usuario> GetLoginAsync(Usuario usuario);
        Task<dynamic> GetTotalPacotesAsync();
        Task<int> GetTotalUsuariosAsync();
        Task<Usuario> GetDetalhesByCodigoAsync(string codigo);
        Task<List<Usuario>> GetCheckin();
        Task<Usuario> GetByCodigoAsync(string codigo);
    }
}
