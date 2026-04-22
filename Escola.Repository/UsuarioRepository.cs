using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly EscolaDbContext _context;

        public UsuarioRepository(EscolaDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorEmailESenha(string email, string senha)
        {
            // Validação dos parâmetros
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email não pode ser vazio.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
            }

            var usuario = await _context.Usuarios
                .AsNoTracking() // Melhora performance para consultas somente leitura
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            return usuario;
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            // Validação do parâmetro
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email não pode ser vazio.", nameof(email));
            }

            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            return usuario;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            // Verifica se já existe um usuário com este email
            var usuarioExistente = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioExistente != null)
            {
                throw new InvalidOperationException($"Já existe um usuário cadastrado com o email: {usuario.Email}");
            }

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
