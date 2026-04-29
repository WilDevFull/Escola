using Escola.Application.Interfaces;
using Escola.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunosController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAluno([FromBody] AlunoRequest request)
        {
            if (string.IsNullOrEmpty(request.NomeAluno) ||
                string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Matricula))
            {
                return BadRequest("Nome, email e matrícula são obrigatórios.");
            }

            await _alunoAppService.AdicionarAluno(request);

            return Ok("Aluno cadastrado com sucesso.");
        }

        [HttpGet]
        public async Task<IActionResult> PesquisarAlunos()
        {
            var alunos = await _alunoAppService.PesquisarAlunos();

            return Ok(alunos);
        }
    }
}