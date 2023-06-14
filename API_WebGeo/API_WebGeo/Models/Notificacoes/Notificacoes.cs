using API_WebGeo.Models.Atividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_WebGeo.Models.Notificacoes
{
    public class Notificacoes
    {
        public int NotificacaoID { get; set; }

        public string Nome { get; set; }

        public string Mensagem { get; set; }

        public string DataEnviada { get; set; }

        public int UtilizadorID { get; set; }

        public int AtividadeID { get; set; }

        public Notificacoes() { }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Notificacoes)
                return ((Notificacoes)obj).NotificacaoID == this.NotificacaoID;
            else
                return false;
        }
    }
}