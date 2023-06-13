using AmigosRESTAPI.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AmigosRESTAPI.Models.Utilizador
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        //public IEnumerable<Utilizador> GetAll()
        //{
        //    //mockUtilizador
        //    return new Utilizador[] {
        //        new Utilizador {Id = 1, Nome = "Zeferino", Email = "asd@asd.com", Password = "123", Coordenadas = "", RaioVizinhanca = 5}
        //    };

        private DataLayer dataLayer = null;

        public UtilizadorRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public IEnumerable<Utilizador> GetAll()
        {
            if (dataLayer != null)
            {
                string erro;
                List<Utilizador> resultado = dataLayer.GetAllUtilizador(out erro);
                if (erro == null && resultado != null && resultado.Count > 0)
                    return resultado.ToArray<Utilizador>();
                else
                    return new Utilizador[0] { };
            }
            else throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}