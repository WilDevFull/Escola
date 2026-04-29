using Escola.Application.Interfaces;
using Escola.Application.ViewModel;
using Escola.Domain.Entities;
using Escola.Domain.Intefaces;

namespace Escola.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoAppService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task AdicionarAluno(AlunoRequest request)
        {
            var aluno = new Aluno
            {
                NomeAluno = request.NomeAluno,
                Email = request.Email,
                Matricula = request.Matricula
            };

            await _alunoRepository.AdicionarAluno(aluno);
        }

        public async Task<List<AlunoResponse>> PesquisarAlunos()
        {
            var alunos = await _alunoRepository.PesquisarAlunos();

            return alunos.Select(a => new AlunoResponse
            {
                AlunoId = a.AlunoId,
                NomeAluno = a.NomeAluno,
                Email = a.Email,
                Matricula = a.Matricula
            }).ToList();
        }
    }
}