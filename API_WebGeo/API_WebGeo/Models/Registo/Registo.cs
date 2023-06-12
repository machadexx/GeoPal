using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_WebGeo.Models.Registo
{
    public class Registo
    {

        public int UtilizadorID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Registo() { }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Registo)
                return ((Registo)obj).UtilizadorID == this.UtilizadorID;
            else
                return false;
        }
    }
}