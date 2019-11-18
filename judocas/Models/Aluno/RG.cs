namespace judocas.Models.Aluno
{
    public class RG
    {
        public long Id { get; set; }
        public long IdAluno { get; set; }
        public string Numero { get; set; }
        public string OrgaoExpedidor { get; set; }
        public Aluno Aluno { get; set; }
    }
}
