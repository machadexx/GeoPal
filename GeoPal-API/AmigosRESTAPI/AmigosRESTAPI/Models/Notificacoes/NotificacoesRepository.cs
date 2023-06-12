using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Notificacoes
{
    public class NotificacoesRepository : INotificacoesRepository
    {
        public IEnumerable<Notificacoes> GetAll()
        {
            //mockNotificacao
            return new Notificacoes[] {
                new Notificacoes {Id = 1, UtilizadorId = 1, AtividadeId = 1, DataEnviada = "asd", Mensagem = "atividade X"},
            };
        }
    }
}