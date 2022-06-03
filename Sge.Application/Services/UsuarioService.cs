using Sge.Application.Interfaces;
using Sge.Data.Interfaces;
using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sge.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Add(Usuario entity)
        {
            _usuarioRepository.Add(entity);
        }

        public void Delete(Usuario entity)
        {
            _usuarioRepository.Delete(entity);
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _usuarioRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _usuarioRepository.SaveChangesAsync();
        }

        public void Update(Usuario entity)
        {
            _usuarioRepository.Update(entity);
        }

        public async Task<Usuario[]> GetAllDetalhesAsync()
        {
            return await _usuarioRepository.GetAllDetalhesAsync();
        }

        public async Task<Usuario> GetDetalhesAsync(int id)
        {
            return await _usuarioRepository.GetDetalhesAsync(id);
        }

        public async Task<Usuario> GetLoginAsync(Usuario usuario)
        {
            var result = await _usuarioRepository.GetLoginAsync(usuario.Email);

            if (result != null && result.Senha == usuario.Senha)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<dynamic> GetTotalPacotesAsync()
        {
            return await _usuarioRepository.GetTotalPacotesAsync();
        }

        public async Task<int> GetTotalUsuariosAsync()
        {
            return await _usuarioRepository.GetTotalUsuariosAsync();
        }

        public async Task<Usuario> GetDetalhesByCodigoAsync(string codigo)
        {
            return await _usuarioRepository.GetDetalhesByCodigoAsync(codigo);
        }

        public async Task<List<Usuario>> GetCheckin()
        {
            return await _usuarioRepository.GetCheckin();
        }

        public async Task<Usuario> GetByCodigoAsync(string codigo)
        {
            return await _usuarioRepository.GetByCodigoAsync(codigo);
        }
    }
}
