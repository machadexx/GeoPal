using AmigosRESTAPI.Models.Atividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AmigosRESTAPI.Controllers
{
    [EnableCors(origins:"http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AtividadesController : ApiController
    {
        private IAtividadesRepository repository;

        public AtividadesController() { }
        public AtividadesController(IAtividadesRepository repository)
        {
            this.repository = repository;
        }

        // GET:
        // exemplo http://localhost/AmigosRESTAPI/api/atividades
        [Route("api/atividades")]
        public IEnumerable<Atividades> GetAll()
        {
            return repository.GetAll();
        }
        [Route("api/atividades/{id}")]
        public IEnumerable<Atividades> GetAtividade()
        {
            return repository.GetAtividade();
        }
    }
}