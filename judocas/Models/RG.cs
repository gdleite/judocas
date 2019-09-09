using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace judocas.Models
{
    public class RG
    {
        public Filiado Filiado { get; set; }
        public long? IdFiliado { get; set; }
        public long? IdRG { get; set; }
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
    }
}
