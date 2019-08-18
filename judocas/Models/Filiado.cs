using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{
    public interface Filiado
    {
        long Id { get; set; }
        string Nome { get; set; }
        string RegistroCbj { get; set; }
        string Telefone1 { get; set; }
        string Telefone2 { get; set; }
        string Email { get; set; }
        string CPF { get; set; }
        string Observacoes { get; set; }
        RG RG { get; set; }
        DateTime DataNascimento { get; set; }
    }
}
