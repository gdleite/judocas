using judocas.Models.Professor;
using System;
using System.Linq;

namespace judocas.Data
{
    public static class DbInitializer
    {

        public static void Initialize(JudocasContext context)
        {

            if (context.Professores.Any())
            {
                return;   // DB has been seeded
            }

            Professor[] professores = new Professor[]
            {
            new Professor {
                Nome = "Carson",
                CPF = "7029282345",
                Email = "Carson@tt.com.br",
                DataNascimento = DateTime.Parse("2010-09-01"),
                Observacoes = "Alergico a amendoim",
                Telefone1 = "99001100",
                Telefone2 = "88191902",
                RegistroCbj = "98212743",
                DataVencimentoCBJ = DateTime.Parse("2018-09-01"),
                Numero = "9521655",
                OrgaoExpedidor = "SDS",
                Bairro = "Vila Mariana",
                CEP = "04019030",
                Cidade = "Sao Paulo",
                Estado = "SP",
                Rua = "Rua Tangara",
                NumeroResidencia = "33"

            },
            new Professor {
                Nome = "Alex",
                CPF = "90909192",
                Email = "AleqGol@gmail.com",
                DataNascimento = DateTime.Parse("1998-09-01"),
                Observacoes = "Medo do escuro",
                Telefone1 = "88997755",
                Telefone2 = "89909818",
                RegistroCbj = "7382919",
                DataVencimentoCBJ = DateTime.Parse("2017-09-01"),
                Numero = "9521655",
                OrgaoExpedidor = "SDS",
                Bairro = "Barra funda",
                CEP = "33990012",
                Cidade = "Teresina",
                Estado = "PI",
                Rua = "Rua Palmas",
                NumeroResidencia = "321"
            }

            };

            foreach (Professor p in professores)
            { 
                context.Professores.Add(p);
            }
            context.SaveChanges();


            var faixas = new Faixa[]
            {
                new Faixa {
                    IdProfessor = professores.Single(s => s.Nome == "Carson").Id,
                    Cor = Faixa.Cores.Laranja,
                    DataEntrega = DateTime.Parse("2012-04-12"),
                    Descricao = "Conquistada no campeonato de ferias"
                },
                new Faixa {
                    IdProfessor = professores.Single(s => s.Nome == "Carson").Id,
                    Cor = Faixa.Cores.Cinza,
                    DataEntrega = DateTime.Parse("2011-04-12"),
                    Descricao = "Conquistada em Teresina"
                },
                new Faixa {
                    IdProfessor = professores.Single(s => s.Nome == "Alex").Id,
                    Cor = Faixa.Cores.Preta5Dan,
                    DataEntrega = DateTime.Parse("2004-11-12"),
                    Descricao = "Conquistada em Alagoas"
                }
            };

            foreach (Faixa e in faixas)
            {
                var faixaInDatabase = context.FaixasProfessores.Where(
                    s => s.Professor.Id == e.IdProfessor).SingleOrDefault();
                if (faixaInDatabase == null)
                {
                    context.FaixasProfessores.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
