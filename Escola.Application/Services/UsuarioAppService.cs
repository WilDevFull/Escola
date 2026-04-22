using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;
        }


        public async Task AdicionarUsuario(string nome, string email, string senha)
        {
            // Simulação de adição de usuário
            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = GerarHashSenha(senha)
            };



            await _usuarioRepository.AdicionarUsuario(usuario);
        }


        public string GerarHashSenha(string senha)
        {

            return BCrypt.Net.BCrypt.HashPassword(senha);






        }

    }
}
