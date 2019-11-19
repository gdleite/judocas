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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimentoCBJ { get; set; }

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
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
        public string Rua { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
  
        public List<Faixa> Faixa { get; set; }

    }
}
