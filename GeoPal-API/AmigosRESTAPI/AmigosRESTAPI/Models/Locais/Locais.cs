using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models
{
    public class Locais
    {
        private int localid;
        private string nome;
        private string coords;

        public int localId { get => localid; set => localid = Math.Abs(value); }
        public string Nome { get => nome; set => nome = value; }

        public string Coords { get => coords; set => coords = value; }

        public Locais() { }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Locais)
                return ((Locais)obj).localId == this.localId;
            else
                return false;
        }
    }
}