using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Atividades
{
    public class Atividades
    {
        private int id;
        private int vizinhancaId;
        private string nome;
        private string localizacao;
        private string inicio;
        private string fim;
        private string coordenadas;

        public int Id { get => id; set => id = Math.Abs(value); }
        public int VizinhancaId { get => vizinhancaId; set => vizinhancaId = Math.Abs(value); }
        public string Nome { get => nome; set => nome = value; }
        public string Localizacao { get => localizacao; set => localizacao = value; }
        public string Inicio { get => inicio; set => inicio = value; }
        public string Fim { get => fim; set => fim = value; }
        public string Coordenadas { get => coordenadas; set => coordenadas = value; }
    }
}