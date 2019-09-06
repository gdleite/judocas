using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{
    public class Aluno : Filiado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string RegistroCbj { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Observacoes { get; set; }
        [Required]
        public RG RG { get; set; }

        public DateTime DataNascimento { get; set; }
        [Required]
        public Faixa Faixa { get; set; }

    }

    public class Professor : Filiado
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Registro CBJ")]
        public string RegistroCbj { get; set; }
        [Required]
        [Display(Name = "Telefone 1")]
        public string Telefone1 { get; set; }
        [Display(Name = "Telefone 2")]
        public string Telefone2 { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string CPF { get; set; }
        [Display(Name = "Observações")]
        [StringLength(100, MinimumLength = 0)]
        public string Observacoes { get; set; }
        
        public virtual RG RG { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }
        
        public virtual Faixa Faixa { get; set; }
    }

    public class Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public Endereco Endereço { get; set; }

    }
}
