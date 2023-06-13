using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Utilizador
{
    public class Utilizador
    {
        private int utilizadorID;
        private string nome;
        private string email;
        private string password;
        private string coordenadas;
        private int raioVizinhanca;

        public int UtilizadorID { get => utilizadorID; set => utilizadorID = Math.Abs(value); }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Coordenadas { get => coordenadas; set => coordenadas = value; }
        public int RaioVizinhanca { get => raioVizinhanca; set => raioVizinhanca = Math.Abs(value); }


    }
}