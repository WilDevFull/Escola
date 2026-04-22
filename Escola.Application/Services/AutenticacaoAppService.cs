using Escola.Application.Interfaces;
using Escola.Application.ViewModel;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.Services
{
    public class AutenticacaoAppService: IAutenticacaoAppService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<UsuarioDTO> Autenticar(string email, string senha)
        {
            // Busca o usuário pelo email
            var usuario = await _usuarioRepository.ObterPorEmail(email);

            // Verifica se o usuário existe e se a senha está correta usando BCrypt
            if (usuario == null || !VerificarSenha(senha, usuario.Senha))
            {
                return new UsuarioDTO();
            }

            return new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome
            };
        }

        /// <summary>
        /// Gera um hash BCrypt da senha fornecida
        /// </summary>
        /// <param name="senha">Senha em texto plano</param>
        /// <returns>Hash BCrypt da senha</returns>
        public string GerarHashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
            }

            // Gera o hash usando BCrypt com workFactor 12 (padrão recomendado)
            return BCrypt.Net.BCrypt.HashPassword(senha, workFactor: 12);
        }

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash armazenado
        /// </summary>
        /// <param name="senha">Senha em texto plano</param>
        /// <param name="hashArmazenado">Hash BCrypt armazenado no banco</param>
        /// <returns>True se a senha corresponder ao hash, False caso contrário</returns>
        public bool VerificarSenha(string senha, string hashArmazenado)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(hashArmazenado))
            {
                return false;
            }

            try
            {
                return BCrypt.Net.BCrypt.Verify(senha, hashArmazenado);
            }
            catch
            {
                // Se houver erro na verificação (hash inválido), retorna false
                return false;
            }
        }
    }
}

