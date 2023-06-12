using AmigosRESTAPI.Models.Utilizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AmigosRESTAPI.Controllers
{
    [EnableCors(origins:"http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UtilizadorController : ApiController
    {
        private IUtilizadorRepository repository;

        public UtilizadorController() { }
        public UtilizadorController(IUtilizadorRepository repository)
        {
            this.repository = repository;
        }

        // GET:
        // exemplo http://localhost/AmigosRESTAPI/api/utilizador
        [Route("api/utilizador")]
        public IEnumerable<Utilizador> GetAll()
        {
            return repository.GetAll();
        }
    }
}