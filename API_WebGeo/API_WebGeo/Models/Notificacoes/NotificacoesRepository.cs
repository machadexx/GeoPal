using API_WebGeo.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_WebGeo.Models.Notificacoes
{
    public class NotificacoesRepository : INotificacoesRepository
    {
        private DataLayer dataLayer = null;

        public NotificacoesRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public async Task<Notificacoes> GetNotificacoes(int NotificacaoID)
        {
            try
            {
                var notificacoes = await dataLayer.GetNotificacoes(NotificacaoID);

                if (NotificacaoID != null)
                {
                    return notificacoes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteNotificacoes(int NotificacaoID)
        {
            try
            {
                await dataLayer.DeleteNotificacoes(NotificacaoID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}