using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Repository
{
    public class EscolaDbContext : DbContext
    {
        public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UsuarioId)
                    .IsRequired();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.ToTable("Usuarios");
            });




        }
    }
}
