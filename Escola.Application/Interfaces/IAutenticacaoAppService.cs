using Escola.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Application.Interfaces
{
    public interface IAutenticacaoAppService
    {
        Task<UsuarioDTO> Autenticar(string email, string senha);
    }
}
