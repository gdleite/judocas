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
        [Required]
        [ForeignKey("Filiado")]
        public long IdFiliado;
        [Key]
        public long IdFaixa { get; set; }
        [Display(Name = "Cor da faixa")]
        public Cores CorFaixa { get; set; }
        [Display(Name = "Data de entrega")]
        public DateTime DataEntrega { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public Faixa(Cores corFaixa, DateTime dataEntrega, string descricao)
        {
            this.CorFaixa = corFaixa;
            this.DataEntrega = dataEntrega;
            this.Descricao = descricao;
        }
    }
}
