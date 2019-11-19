using System.Collections.Generic;

namespace judocas.Models.Relacao
{
    public class ProfessorIndexData
    {
        public IEnumerable<Entidade.Entidade> Entidades { get; set; }
        public IEnumerable<Professor.Professor> Professores { get; set; }
    }
}
