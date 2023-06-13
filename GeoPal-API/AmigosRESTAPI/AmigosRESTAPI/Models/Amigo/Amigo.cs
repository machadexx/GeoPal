using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models {
    public class Amigo {
        private int utilizador;
        private int utilizador2;
        private string inicio;

        public int Utilizador { get => utilizador; set => utilizador = Math.Abs(value); }
        public int Utilizador2 { get => utilizador2; set => utilizador2 = value; }
        public string Inicio { get => inicio; set => inicio = value; }

        public Amigo() { }

        public override bool Equals(object obj) {
            if (obj != null && obj is Amigo)
                return ((Amigo)obj).utilizador == this.utilizador;
            else
                return false;
        }
    }
}