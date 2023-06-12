using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Notificacoes
{
    public interface INotificacoesRepository
    {
        IEnumerable<Notificacoes> GetAll();
    }
}