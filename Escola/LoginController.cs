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


        public LoginController(IJwtAppService jwtAppService
            , IAutenticacaoAppService autenticacaoAppService)
        {
            _jwtAppService = jwtAppService;
            _autenticacaoAppService = autenticacaoAppService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
            {
                return BadRequest(new LoginResponse
                {
                    Sucesso = false,
                    Mensagem = "Email e senha são obrigatórios."
                });
            }




            var usuarioDTO = await _autenticacaoAppService.Autenticar(request.Email, request.Senha);

            if (usuarioDTO == null)
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
                Token = _token
            });


        }



    }


}
