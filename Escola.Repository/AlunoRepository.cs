using Escola.Domain.Entities;
using Escola.Domain.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaDbContext _db;

        public AlunoRepository(EscolaDbContext escolaDbContext)
        {
            _db = escolaDbContext;
        }

        public async Task AdicionarAluno(Aluno aluno)
        {
            var alunoExiste = await _db.Alunos
                .FirstOrDefaultAsync(a => a.Matricula == aluno.Matricula);

            if (alunoExiste != null)
            {
                throw new Exception("Já existe um aluno com essa matrícula.");
            }

            await _db.Alunos.AddAsync(aluno);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Aluno>> PesquisarAlunos()
        {
            return await _db.Alunos.ToListAsync();
        }

        public async Task<Aluno?> ObterAlunoPorMatricula(string matricula)
        {
            return await _db.Alunos
                .FirstOrDefaultAsync(a => a.Matricula == matricula);
        }
    }
}