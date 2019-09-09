using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace judocas.Models
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
        public long? IdFiliado { get; set; }
        public long? IdFaixa { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public Filiado Filiado { get; set; }

    }
}
