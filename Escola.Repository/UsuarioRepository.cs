using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;

namespace Escola.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public UsuarioRepository()
        {
        }

        public async Task<Usuario> ObterPorEmailESenha(string email, string senha)
        {
            // Simulação de acesso ao banco de dados

            

            var usuario = new Usuario
            {
                Id = 1,
                Email = "teste@email.com",
                Senha = "123456",
                Nome = "Usuário Teste"
            };

            return usuario;

        }

    }
}
