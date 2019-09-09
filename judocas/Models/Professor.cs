using System;
using System.ComponentModel.DataAnnotations;

namespace judocas.Models
{
    public class Professor
    {
       
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string RegistroCbj { get; set; }
        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public long IdRG { get; set; }
        public string Observacoes { get; set; }
        
        public  RG RG { get; set; }
        public DateTime DataNascimento { get; set; }
    
        public  Faixa Faixa { get; set; }
    }
}
