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
            // Simulação de autenticação


            var usuario =  await _usuarioRepository.ObterPorEmailESenha(email, senha);

            if (usuario == null)
            {
                return new UsuarioDTO();
            }

            return new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome
            };
        }
    }
}
