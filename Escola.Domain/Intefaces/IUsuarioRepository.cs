using Escola.Domain.Entities;

namespace Escola.Domain.Intefaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorEmailESenha(string email, string senha);
        Task<Usuario> ObterPorEmail(string email);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
    }
}
