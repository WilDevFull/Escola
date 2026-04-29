using Escola.Domain.Entities;

namespace Escola.Domain.Intefaces
{
	public interface IAlunoRepository
	{
		Task AdicionarAluno(Aluno aluno);
		Task<List<Aluno>> PesquisarAlunos();
		Task<Aluno?> ObterAlunoPorMatricula(string matricula);
	}
}