using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace judocas.Models
{
    public class RG
    {
        [Required]
        [ForeignKey("Filiado")]
        public long IdFiliado;

        [Key]
        public string Numero { get; set; }
        [Display(Name = "Orgão expedidor")]
        public string OrgaoExpedidor { get; set; }
        public RG(string numero, string orgaoExpedidor)
        {
            this.OrgaoExpedidor = orgaoExpedidor;
            this.Numero = numero;
        }

    }
}
