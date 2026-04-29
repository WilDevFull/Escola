using Escola.Application.ViewModel;

namespace Escola.Application.Interfaces
{
    public interface IAlunoAppService
    {
        Task AdicionarAluno(AlunoRequest request);
        Task<List<AlunoResponse>> PesquisarAlunos();
    }
}