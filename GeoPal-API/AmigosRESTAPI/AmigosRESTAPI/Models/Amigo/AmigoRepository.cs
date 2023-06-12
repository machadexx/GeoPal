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
    public class AmigoRepository : IAmigoRepository
    {
        //public IEnumerable<Amigo> GetAll()
        //{
        //    return new Amigo[] {
        //        new Amigo {IdAmigo = 1000, Nome = "Zeferino"},
        //        new Amigo {IdAmigo = 1001, Nome = "Sebastiao" },
        //        new Amigo {IdAmigo = 1002, Nome = "Valentim"},
        //        new Amigo {IdAmigo = 1003, Nome = "Vilaça"}
        //    };
        //}

        private DataLayer dataLayer = null;

        public AmigoRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public IEnumerable<Amigo> GetAll()
        {
            if (dataLayer != null)
            {
                string erro;
                List<Amigo> resultado = dataLayer.GetAllAmimgos(out erro);
                if (erro == null && resultado != null && resultado.Count > 0)
                    return resultado.ToArray<Amigo>();
                else
                    return new Amigo[0] { };
            }
            else throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}