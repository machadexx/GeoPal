using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_WebGeo.Models.Utilizador
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public int RaioVizinhança { get; set; }

        public double? Coordenadas_latitude { get; set; }

        public double? Coordenadas_longitude { get; set; }

        public Utilizador() { }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Utilizador)
                return ((Utilizador)obj).UtilizadorID == this.UtilizadorID;
            else
                return false;
        }
    }
}