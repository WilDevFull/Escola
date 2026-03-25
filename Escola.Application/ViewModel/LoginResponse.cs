using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.ViewModel
{
    public class LoginResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public UsuarioDTO? Usuario { get; set; } = new UsuarioDTO();


    }

}
