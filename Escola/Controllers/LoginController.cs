using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Escola
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAppService _jwtAppService;
        private readonly IAutenticacaoAppService _autenticacaoAppService;
        private readonly IUsuarioAppService _usuarioAppService;


        public LoginController(IJwtAppService jwtAppService
            , IAutenticacaoAppService autenticacaoAppService
            , IUsuarioAppService usuarioAppService)
        {
            _jwtAppService = jwtAppService;
            _autenticacaoAppService = autenticacaoAppService;
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }



            if (string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest(new UsuarioResponse { Sucesso = false, Mensagem = "Nome, email e senha são obrigatórios." });
            }


            if (request.Senha.Length < 6)
            {
                return BadRequest(new UsuarioResponse { Sucesso = false, Mensagem = "A senha deve conter pelo menos 6 caracteres." });
            }



            if (!request.Email.Contains("@") || !request.Email.Contains("."))
            {
                return BadRequest(new UsuarioResponse { Sucesso = false, Mensagem = "Email inválido." });
            }

            try
            {
                await _usuarioAppService.AdicionarUsuario(request.Nome, request.Email, request.Senha);

                return Ok(new UsuarioResponse
                {
                    Sucesso = true,
                    Mensagem = "Usuário registrado com sucesso."


                });
            }
            catch (Exception ex)
            {

                //return BadRequest(new UsuarioResponse { Sucesso = false, Mensagem = ex.Message });

                return StatusCode(500, new UsuarioResponse
                {
                    Sucesso = false,
                    Mensagem = ex.Message

                });




                throw;
            }




        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest(new LoginResponse
                {
                    Sucesso = false,
                    Mensagem = "Email e senha são obrigatórios."
                });
            }




            var usuarioDTO = await _autenticacaoAppService.Autenticar(request.Email, request.Senha);

            if (string.IsNullOrEmpty(usuarioDTO?.Email))
            {
                return Unauthorized(new LoginResponse
                {
                    Sucesso = false,
                    Mensagem = "Email ou senha inválidos."
                });
            }




            var _token = _jwtAppService.GerarToken(usuarioDTO);




            return Ok(new LoginResponse
            {
                Sucesso = true,
                Mensagem = "Login realizado com sucesso.",
                Token = _token,
                Usuario = usuarioDTO
            });


        }

    }


}