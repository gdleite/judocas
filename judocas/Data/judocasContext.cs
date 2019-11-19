using Microsoft.EntityFrameworkCore;
using judocas.Models.Professor;
using judocas.Models.Aluno;
using judocas.Models.Entidade;

namespace judocas.Data
{
    public class JudocasContext : DbContext
    {
        public JudocasContext(DbContextOptions<JudocasContext> options)
            : base(options)
        {
        }
        // Professores
        public DbSet<judocas.Models.Professor.Professor> Professores { get; set; }
        public DbSet<judocas.Models.Professor.Faixa> FaixasProfessores { get; set; }

        // Alunos
        public DbSet<judocas.Models.Aluno.Aluno> Alunos { get; set; }
        public DbSet<judocas.Models.Aluno.Faixa> FaixasAlunos { get; set; }

        // Entidade
        public DbSet<judocas.Models.Entidade.Entidade> Entidades { get; set; }

        // Relacao
        public DbSet<judocas.Models.Relacao.ProfessorEntidade> ProfessoresEntidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Professores
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Models.Professor.Faixa>().ToTable("Faixa");

            // Alunos
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Models.Aluno.Faixa>().ToTable("FaixaAluno");

            //Entidade
            modelBuilder.Entity<Entidade>().ToTable("Entidade");
            modelBuilder.Entity<Models.Relacao.ProfessorEntidade>().ToTable("ProfessorEntidade");

            //Ajustes banco de dados
            modelBuilder.Entity<Models.Relacao.ProfessorEntidade>()
                .HasKey(c => new { c.EntidadeID, c.ProfessorID });
        }
    }
}
