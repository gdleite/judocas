using System.Collections.Generic;

namespace judocas.Models.Professor
{
    public class ProfessorIndexData
    {
        public IEnumerable<Professor> Professores { get; set; }
        public IEnumerable<Faixa> Faixas { get; set; }
    }
}
