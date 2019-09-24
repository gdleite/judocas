using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace judocas.Models
{
    public class ProfessorIndexData
    {
        public IEnumerable<Professor> Professores { get; set; }
        public IEnumerable<Faixa> Faixas { get; set; }
    }
}
