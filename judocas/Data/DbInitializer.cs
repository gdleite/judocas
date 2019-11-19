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
                RegistroCbj = "98212743"
            },
            new Professor {
                Nome = "Alex",
                CPF = "90909192",
                Email = "AleqGol@gmail.com",
                DataNascimento = DateTime.Parse("1998-09-01"),
                Observacoes = "Medo do escuro",
                Telefone1 = "88997755",
                Telefone2 = "89909818",
                RegistroCbj = "7382919"
            }

            };

            foreach (Professor p in professores)
            {
                Console.WriteLine("Professores ja foram adicionados em um outro momento");
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
                    Console.WriteLine("Faixas ja foram adicionados em um outro momento");
                    context.FaixasProfessores.Add(e);
                }
            }
            context.SaveChanges();


            var RGsProf = new RG[]
            {
                new RG {
                    IdProfessor = professores.Single(s => s.Nome == "Carson").Id,
                    Numero = "9521655",
                    OrgaoExpedidor = "SDS"
                },
                new RG {
                    IdProfessor = professores.Single(s => s.Nome == "Alex").Id,
                    Numero = "9521655",
                    OrgaoExpedidor = "SDS"
                }
            };

            foreach (RG e in RGsProf)
            {
                var RGsInDatabase = context.RGProfessores.Where(
                    s => s.Professor.Id == e.IdProfessor).SingleOrDefault();
                if (RGsInDatabase == null)
                {
                    Console.WriteLine("RGs ja foram adicionados em um outro momento");
                    context.RGProfessores.Add(e);
                }
            }
            context.SaveChanges();


            var Enderecos = new Endereco[]
            {
                new Endereco {
                    IdProfessor = professores.Single(s => s.Nome == "Carson").Id,
                    Bairro = "Vila Mariana",
                    CEP = "04019030",
                    Cidade = "Sao Paulo",
                    Estado = "SP",
                    Rua = "Rua Tangara",
                    Numero = "33"
                },
                new Endereco {
                    IdProfessor = professores.Single(s => s.Nome == "Alex").Id,
                    Bairro = "Barra funda",
                    CEP = "33990012",
                    Cidade = "Teresina",
                    Estado = "PI",
                    Rua = "Rua Palmas",
                    Numero = "321"
                }
            };

            foreach (Endereco e in Enderecos)
            {
                var EnderecosinDatabase = context.EnderecosProfessores.Where(
                    s => s.Professor.Id == e.IdProfessor).SingleOrDefault();
                if (EnderecosinDatabase == null)
                {
                    Console.WriteLine("Endereços ja foram adicionados em um outro momento");
                    context.EnderecosProfessores.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
