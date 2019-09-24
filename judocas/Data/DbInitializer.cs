using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using judocas.Models;

namespace judocas.Data
{
    public static class DbInitializer
    {

        public static void Initialize(judocasContext context){

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
                }
            };

            foreach (Faixa e in faixas)
            {
                var enrollmentInDataBase = context.Faixas.Where(
                    s => s.Professor.Id == e.IdProfessor).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Faixas.Add(e);
                }
            }
            context.SaveChanges();

            }
    }
}
