﻿using System;
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
        public DbSet<judocas.Models.Filiado> Filiados { get; set; }
        public DbSet<judocas.Models.Faixa> Faixas { get; set; }
        public DbSet<judocas.Models.RG> RG { get; set; }
        //public DbSet<judocas.Models.Entidade> Entidades { get; set; }
        //public DbSet<judocas.Models.Professor> Professores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filiado>().ToTable("Filiado");
            modelBuilder.Entity<Filiado>().HasKey(a => a.IdFiliado);
            modelBuilder.Entity<Filiado>().Property(a => a.IdFiliado).HasColumnType("BIGINT").HasColumnName("ID_FILIADO").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.Nome).HasColumnName("NOME").HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.RegistroCbj).HasColumnName("REGISTRO_CBJ").HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.Telefone1).HasColumnName("TELEFONE_1").HasColumnType("nvarchar(20)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.Telefone2).HasColumnName("TELEFONE_2").HasColumnType("nvarchar(20)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.Email).HasColumnName("EMAIL").HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.CPF).HasColumnName("CPF").HasColumnType("nvarchar(11)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.Observacoes).HasColumnName("OBSERVACOES").HasColumnType("nvarchar(255)").IsRequired();
            modelBuilder.Entity<Filiado>().Property(a => a.DataNascimento).HasColumnName("DATA_NASC").HasColumnType("datetime2").IsRequired();


            //modelBuilder.Entity<Aluno>().ToTable("Aluno");
            //modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            //modelBuilder.Entity<Aluno>().Property(a => a.Id).HasColumnType("BIGINT").HasColumnName("ID_ALUNO").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.Nome).HasColumnName("NOME").HasColumnType("nvarchar(255)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.RegistroCbj).HasColumnName("REGISTRO_CBJ").HasColumnType("nvarchar(255)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.Telefone1).HasColumnName("TELEFONE_1").HasColumnType("nvarchar(20)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.Telefone2).HasColumnName("TELEFONE_2").HasColumnType("nvarchar(20)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.Email).HasColumnName("EMAIL").HasColumnType("nvarchar(255)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.CPF).HasColumnName("CPF").HasColumnType("nvarchar(11)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.Observacoes).HasColumnName("OBSERVACOES").HasColumnType("nvarchar(255)").IsRequired();
            //modelBuilder.Entity<Aluno>().Property(a => a.DataNascimento).HasColumnName("DATA_NASC").HasColumnType("datetime2").IsRequired();


            modelBuilder.Entity<Faixa>().ToTable("Faixa");
            modelBuilder.Entity<Faixa>().HasKey(a => a.IdFaixa);
            modelBuilder.Entity<Faixa>().Property(a => a.IdFaixa).HasColumnType("BIGINT").HasColumnName("ID_FAIXA").IsRequired();
            modelBuilder.Entity<Faixa>().Property(a => a.IdFiliado).HasColumnType("BIGINT").HasColumnName("ID_FILIADO").IsRequired();
            modelBuilder.Entity<Faixa>().Property(a => a.Descricao).HasColumnType("nvarchar(50)").HasColumnName("DESCRICAO_FAIXA").IsRequired();
            modelBuilder.Entity<Faixa>().Property(a => a.DataEntrega).HasColumnName("DATA_ENTREGA").HasColumnType("datetime2").IsRequired();
            modelBuilder.Entity<Faixa>().HasOne(a => a.Filiado).WithMany(a => a.Faixas).HasForeignKey(a => a.IdFiliado);

            modelBuilder.Entity<RG>().ToTable("RG");
            modelBuilder.Entity<RG>().HasKey(a => a.IdRG);
            modelBuilder.Entity<RG>().Property(a => a.IdFiliado).HasColumnType("BIGINT").HasColumnName("ID_FILIADO").IsRequired();
            modelBuilder.Entity<RG>().Property(a => a.IdRG).HasColumnType("BIGINT").HasColumnName("ID_RG").IsRequired();
            modelBuilder.Entity<RG>().HasOne(a => a.Filiado).WithOne(a => a.RG).HasForeignKey<Filiado>(a => a.IdFiliado);

            //modelBuilder.Entity<Entidade>().ToTable("Entidades");
            //modelBuilder.Entity<Professor>().ToTable("Professores");
        }
    }
}
