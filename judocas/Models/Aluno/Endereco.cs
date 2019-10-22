using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models.Aluno
{
    public class Endereco
    {
        public long Id { get; set; }
        public long IdAluno { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Aluno Aluno { get; set; }

    }
}
