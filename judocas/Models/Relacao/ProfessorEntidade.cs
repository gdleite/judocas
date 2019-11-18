namespace judocas.Models.Relacao
{
    public class ProfessorEntidade
    {
        public long ProfessorID { get; set; }
        public long EntidadeID { get; set; }
        public Professor.Professor Professor { get; set; }
        public Entidade.Entidade Entidade { get; set; }
    }
}

