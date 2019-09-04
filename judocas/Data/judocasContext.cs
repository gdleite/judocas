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

        public DbSet<judocas.Models.Aluno> Alunos { get; set; }
        public DbSet<judocas.Models.Entidade> Entidades { get; set; }
        public DbSet<judocas.Models.Professor> Professores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Entidade>().ToTable("Entidades");
            modelBuilder.Entity<Professor>().ToTable("Professores");
        }
    }
}
