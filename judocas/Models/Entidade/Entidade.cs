using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace judocas.Models.Entidade
{

    public class Entidade
    {
        public long Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Nome { get; set; }
        [Required]
        [StringLength(18, MinimumLength = 1)]
        public string CNPJ { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string Telefone1 { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 1)]
        public string Telefone2 { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public ICollection<Relacao.ProfessorEntidade> ProfessorEntidade { get; set; }
    }
}
