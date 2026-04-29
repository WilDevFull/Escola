namespace Escola.Application.ViewModel
{
    public class AlunoResponse
    {
        public Guid AlunoId { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
    }
}