using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WebGeo.Models.Notificacoes
{
    public interface INotificacoesRepository
    {
        Task<Notificacoes> GetNotificacoes(int NotificacaoID);

        Task<bool> DeleteNotificacoes(int NotificacaoID);

    }
}
