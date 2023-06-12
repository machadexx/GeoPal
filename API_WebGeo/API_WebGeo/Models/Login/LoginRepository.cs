using API_WebGeo.Persistent;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;



namespace API_WebGeo.Models.Login
{
    public class LoginRepository : ILoginRepository
    {
        private DataLayer dataLayer = null;

        public LoginRepository()
        {
            dataLayer = new DataLayer(ConfigurationManager.ConnectionStrings["Postgres_Provider"].ConnectionString);
        }

        public async Task<bool> IsValidUser(string email, string password)
        {
            
            var user = await dataLayer.GetUserByEmail(email);

            if (user != null && user.Password == password)
            {
                return true;
            }

            return false;
        }


    }
}