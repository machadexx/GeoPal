using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_WebGeo.Models.Login
{
    public interface ILoginRepository
    {
        Task<bool> IsValidUser(string email, string password);        
    }
}