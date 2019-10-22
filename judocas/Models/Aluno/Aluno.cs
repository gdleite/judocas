using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace judocas.Models.Aluno
{
    public class Aluno
    {
        public long Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string RegistroCbj { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string Telefone1 { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string Telefone2 { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string CPF { get; set; }
        public string Observacoes { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public List<Faixa> Faixa { get; set; }

        public  RG RG { get; set; }

        public Endereco Endereco { get; set; }

    }
}
