using AmigosRESTAPI.Models.Notificacoes;
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
    public class NotificacoesController : ApiController
    {
        private INotificacoesRepository repository;

        public NotificacoesController() { }
        public NotificacoesController(INotificacoesRepository repository)
        {
            this.repository = repository;
        }

        // GET:
        // exemplo http://localhost/AmigosRESTAPI/api/notificacoes
        [Route("api/notificacoes")]
        public IEnumerable<Notificacoes> GetAll()
        {
            return repository.GetAll();
        }
    }
}