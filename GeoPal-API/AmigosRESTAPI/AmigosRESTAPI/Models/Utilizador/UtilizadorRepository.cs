using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Utilizador
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        public IEnumerable<Utilizador> GetAll()
        {
            //mockUtilizador
            return new Utilizador[] {
                new Utilizador {Id = 1, Nome = "Zeferino", Email = "asd@asd.com", Password = "123", Coordenadas = "", RaioVizinhanca = 5}
            };
        }
    }
}