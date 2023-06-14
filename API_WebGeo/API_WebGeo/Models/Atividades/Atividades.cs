using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_WebGeo.Models.Atividades
{
    public class Atividades
    {
        public int AtividadeID { get; set; }

        public string Nome { get; set; }

        public string Localizaçao { get; set; }

        public string Inicio { get; set; }

        public string Fim { get; set; }

        public double? Coordenadas_latitude { get; set; }

        public double? Coordenadas_longitude { get; set; }

        public int VizinhancaID { get; set; }

        public Atividades() { }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Atividades)
                return ((Atividades)obj).AtividadeID == this.AtividadeID;
            else
                return false;
        }
    }
}