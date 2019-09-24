using System;
using System.ComponentModel.DataAnnotations;

namespace judocas.Models
{
    public class ProfessorGrupo
    {
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        public int ContagemProfessores { get; set; }
    }
}