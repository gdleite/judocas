using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{

    public class Entidade
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public Endereco Endereço { get; set; }

    }
}
