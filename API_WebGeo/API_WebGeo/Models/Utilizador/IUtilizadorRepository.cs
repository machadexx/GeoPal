using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_WebGeo.Models.Utilizador
{
    public interface IUtilizadorRepository
    {
        Task<Utilizador> GetUserByLogin(string email, string password);

        Task<bool> DeleteUtilizador(int utilizadorID);

    }
}