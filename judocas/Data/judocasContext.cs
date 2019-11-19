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
        public DbSet<judocas.Models.Professor.RG> RGProfessores { get; set; }
        public DbSet<judocas.Models.Professor.Endereco> EnderecosProfessores { get; set; }

        // Alunos
        public DbSet<judocas.Models.Aluno.Aluno> Alunos { get; set; }
        public DbSet<judocas.Models.Aluno.Faixa> FaixasAlunos { get; set; }
        public DbSet<judocas.Models.Aluno.RG> RGAlunos { get; set; }
        public DbSet<judocas.Models.Aluno.Endereco> EnderecosAlunos { get; set; }

        // Entidade
        public DbSet<judocas.Models.Entidade.Entidade> Entidades { get; set; }

        // Relacao
        public DbSet<judocas.Models.Relacao.ProfessorEntidade> ProfessoresEntidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Professores
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Models.Professor.Faixa>().ToTable("Faixa");
            modelBuilder.Entity<Models.Professor.RG>().ToTable("RG");
            modelBuilder.Entity<Models.Professor.Endereco>().ToTable("Endereco");

            // Ajustes banco de dados
            modelBuilder.Entity<Professor>()
            .HasOne(a => a.RG)
            .WithOne(a => a.Professor)
            .HasForeignKey<Models.Professor.RG>(c => c.IdProfessor);

            modelBuilder.Entity<Professor>()
            .HasOne(a => a.Endereco)
            .WithOne(a => a.Professor)
            .HasForeignKey<Models.Professor.Endereco>(c => c.IdProfessor);

            // Alunos
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Models.Aluno.Faixa>().ToTable("FaixaAluno");
            modelBuilder.Entity<Models.Aluno.RG>().ToTable("RGAluno");
            modelBuilder.Entity<Models.Aluno.Endereco>().ToTable("EnderecoAluno");

            // Ajustes banco de dados
            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.RG)
            .WithOne(a => a.Aluno)
            .HasForeignKey<Models.Aluno.RG>(c => c.IdAluno);

            modelBuilder.Entity<Aluno>()
            .HasOne(a => a.Endereco)
            .WithOne(a => a.Aluno)
            .HasForeignKey<Models.Aluno.Endereco>(c => c.IdAluno);

            //Entidade
            modelBuilder.Entity<Entidade>().ToTable("Entidade");
            modelBuilder.Entity<Models.Relacao.ProfessorEntidade>().ToTable("ProfessorEntidade");

            //Ajustes banco de dados
            modelBuilder.Entity<Models.Relacao.ProfessorEntidade>()
                .HasKey(c => new { c.EntidadeID, c.ProfessorID });
        }
    }
}
