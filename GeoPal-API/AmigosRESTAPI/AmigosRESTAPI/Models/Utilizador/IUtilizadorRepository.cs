using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Utilizador
{
    public interface IUtilizadorRepository
    {
        IEnumerable<Utilizador> GetAll();
    }
}