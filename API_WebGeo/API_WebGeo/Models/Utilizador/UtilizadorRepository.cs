using API_WebGeo.Models.Registo;
using API_WebGeo.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API_WebGeo.Models.Utilizador
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private DataLayer dataLayer = null;

        public UtilizadorRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public async Task<Utilizador> GetUserByLogin(string email, string password)
        {
            try
            {
                var user = await dataLayer.GetUserByEmail(email);

                if (user != null && user.Password == password)
                {
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUtilizador(int utilizadorID)
        {
            try
            {
                await dataLayer.DeleteUtilizador(utilizadorID);
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public async Task<bool> UpdateUtilizador(Utilizador utilizador)
        {
            try
            {
                await dataLayer.UpdateUtilizador(utilizador);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}