using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace judocas.Models
{
    public class RG
    {
        public Aluno Aluno { get; set; }
        [Key]
        public long AlunoId { get; set; }
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
    }
}
