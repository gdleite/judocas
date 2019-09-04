using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{
    public class RG
    {
     
        [Key]
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
        public RG(string numero, string orgaoExpedidor)
        {
            this.OrgaoExpedidor = orgaoExpedidor;
            this.Numero = numero;
        }

    }
}
