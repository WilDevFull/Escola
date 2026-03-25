using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = Guid.NewGuid();
            Nome = string.Empty;
            Email = string.Empty;
            Senha = string.Empty;
        }

        public int Id { get; set; }
        public Guid UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
