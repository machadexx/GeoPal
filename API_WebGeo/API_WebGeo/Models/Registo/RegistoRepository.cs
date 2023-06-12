using API_WebGeo.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace API_WebGeo.Models.Registo
{
    public class RegistoRepository : IRegistoRepository
    {
        private DataLayer dataLayer = null;

        public RegistoRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public Registo GetByEmail(string email)
        {
            if (dataLayer != null)
            {
                string erro;
                Registo resultado = dataLayer.GetRegistoByEmail(email, out erro);
                if (erro == null)
                    return resultado;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        public void Create(Registo registo)
        {
            if (dataLayer != null)
            {
                string erro;
                dataLayer.CreateRegisto(registo, out erro);
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