using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using judocas.Models;

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
        public DbSet<judocas.Models.Professor> Professores { get; set; }
        public DbSet<judocas.Models.Faixa> Faixas { get; set; }
        public DbSet<judocas.Models.RG> RG { get; set; }
        public DbSet<judocas.Models.Endereco> Enderecos { get; set; }
        //public DbSet<judocas.Models.Entidade> Entidades { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Faixa>().ToTable("Faixa");
            modelBuilder.Entity<RG>().ToTable("RG");

            // Ajustes banco de dados
            modelBuilder.Entity<Professor>()
            .HasOne(a => a.RG)
            .WithOne(a => a.Professor)
            .HasForeignKey<RG>(c => c.IdProfessor);

            modelBuilder.Entity<Professor>()
            .HasOne(a => a.Endereco)
            .WithOne(a => a.Professor)
            .HasForeignKey<Endereco>(c => c.IdProfessor);
        }
    }
}
