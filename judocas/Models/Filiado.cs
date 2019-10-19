using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{
    public class Filiado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? IdFiliado { get; set; }
        public string Nome { get; set; }
        public string RegistroCbj { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Observacoes { get; set; }
        //public RG RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Faixa> Faixas { get; set; }
        public Endereco Endereco { get; set; }
    }
}
