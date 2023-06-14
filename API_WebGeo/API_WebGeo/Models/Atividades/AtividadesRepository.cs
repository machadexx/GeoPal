using API_WebGeo.Models.Utilizador;
using API_WebGeo.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API_WebGeo.Models.Atividades
{
    public class AtividadesRepository : IAtividadesRepository
    {
        private DataLayer dataLayer = null;

        public AtividadesRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public async Task<Atividades> GetAtividades(int AtividadeID)
        {
            try
            {
                var atividade = await dataLayer.GetAtividades(AtividadeID);

                if (AtividadeID != null)
                {
                    return atividade;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAtividade(int AtividadeID)
        {
            try
            {
                await dataLayer.DeleteAtividades(AtividadeID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Create(Atividades atividades)
        {
            if (dataLayer != null)
            {
                string erro;
                dataLayer.CreateAtividade(atividades, out erro);
                if (erro != null)
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }


    }
}