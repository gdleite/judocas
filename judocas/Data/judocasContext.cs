using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using judocas.Models.Professor;
using judocas.Models.Aluno;

namespace judocas.Data
{
    public class judocasContext : DbContext
    {
        public judocasContext (DbContextOptions<judocasContext> options)
            : base(options)
        {
        }
        //public DbSet<judocas.Models.Aluno> Alunos { get; set; }
        //public DbSet<judocas.Models.Filiado> Filiados { get; set; }
        public DbSet<judocas.Models.Professor.Professor> Professores { get; set; }
        public DbSet<judocas.Models.Professor.Faixa> FaixasProfessores { get; set; }
        public DbSet<judocas.Models.Professor.RG> RGProfessores { get; set; }
        public DbSet<judocas.Models.Professor.Endereco> EnderecosProfessores { get; set; }

        // Alunos
        public DbSet<judocas.Models.Aluno.Aluno> Alunos { get; set; }
        public DbSet<judocas.Models.Aluno.Faixa> FaixasAlunos { get; set; }
        public DbSet<judocas.Models.Aluno.RG> RGAlunos { get; set; }
        public DbSet<judocas.Models.Aluno.Endereco> EnderecosAlunos { get; set; }
        //public DbSet<judocas.Models.Entidade> Entidades { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
