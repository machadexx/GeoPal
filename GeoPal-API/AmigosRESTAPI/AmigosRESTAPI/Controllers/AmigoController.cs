using AmigosRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AmigosRESTAPI.Controllers {
    public class AmigoController : ApiController {
        private IAmigoRepository repository;

        public AmigoController() { }
        public AmigoController(IAmigoRepository repository) {
            this.repository = repository;
        }

        // GET:
        // exemplo http://localhost/AmigosRESTAPI/api/amigo
        [Route("api/amigo")]
        public IEnumerable<Amigo> GetAll() {
            return repository.GetAll();
        }

    }
}