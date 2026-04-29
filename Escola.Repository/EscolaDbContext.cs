

using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repository
{
    public class EscolaDbContext: DbContext
    {

        public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options)
        {
                
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(300);

                

                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(100);

                entity.ToTable("Usuarios");


            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NomeAluno)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Matricula)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.ToTable("Alunos");
            });

        }

    }
}
