using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace judocas.Models.Professor
{
    public class RG
    {
        public long Id { get; set; }
        public long IdProfessor { get; set; }
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
        public Professor Professor { get; set; }
    }
}
