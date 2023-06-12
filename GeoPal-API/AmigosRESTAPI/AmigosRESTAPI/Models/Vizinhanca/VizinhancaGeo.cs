using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Vizinhanca
{
    public class VizinhancaGeo
    {
        private int id;
        private int utilizadorId;
        private string nome;
        private string descricao;

        public int Id { get => id; set => id = Math.Abs(value); }
        public int UtilizadorId { get => utilizadorId; set => utilizadorId = Math.Abs(value); }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}