using System;
using System.ComponentModel.DataAnnotations;

namespace judocas.Models.Professor
{

    public class Faixa
    {
        public enum Cores
        {
            Branca,
            Cinza,
            Azul,
            Amarela,
            Laranja,
            Verde,
            Roxa,
            Marrom,
            Preta1Dan,
            Preta2Dan,
            Preta3Dan,
            Preta4Dan,
            Preta5Dan,
            Preta6Dan,
            Preta7Dan,
            Coral6Dan,
            Coral7Dan,
            Vermelha8Dan,
            Vermelha9Dan,
            Vermelha10Dan
        }
        public long IdProfessor { get; set; }
        public long Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public Professor Professor { get; set; }

        [DisplayFormat(NullDisplayText = "Sem faixa")]
        public Cores? Cor { get; set; }

    }
}
