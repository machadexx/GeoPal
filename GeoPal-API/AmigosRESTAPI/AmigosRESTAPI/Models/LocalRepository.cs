using AmigosRESTAPI.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AmigosRESTAPI.Models
{
    public class LocaisRepository : ILocaisRepository
    {

        private DataLayer dataLayer = null;

        public LocaisRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public IEnumerable<Locais> GetAll()
        {
            if (dataLayer != null)
            {
                string erro;
                List<Locais> resultado = dataLayer.GetAllLocais(out erro);
                if (erro == null && resultado != null && resultado.Count > 0)
                    return resultado.ToArray<Locais>();
                else
                    return new Locais[0] { };
            }
            else throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}