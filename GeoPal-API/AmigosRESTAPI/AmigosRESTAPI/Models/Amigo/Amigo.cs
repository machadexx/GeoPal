using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models {
    public class Amigo {
        private int idAmigo;
        private string nome;
        private string urlfoto;

        public int IdAmigo { get => idAmigo; set => idAmigo = Math.Abs(value); }
        public string Nome { get => nome; set => nome = value; }
        public string Urlfoto { get => urlfoto; set => urlfoto = value; }

        public Amigo() { }

        public override bool Equals(object obj) {
            if (obj != null && obj is Amigo)
                return ((Amigo)obj).IdAmigo == this.idAmigo;
            else
                return false;
        }
    }
}