using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Notificacoes
{
    public class Notificacoes
    {
        private int id;
        private int utilizadorId;
        private int atividadeId;
        private string mensagem;
        private string dataEnviada;

        public int Id { get => id; set => id = Math.Abs(value); }
        public int UtilizadorId { get => utilizadorId; set => utilizadorId = Math.Abs(value); }
        public int AtividadeId { get => atividadeId; set => atividadeId = Math.Abs(value); }
        public string Mensagem { get => mensagem; set => mensagem = value; }
        public string DataEnviada { get => dataEnviada; set => dataEnviada = value; }
    }
}