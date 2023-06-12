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

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int RaioVizinhança { get; set; }

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