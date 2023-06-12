using API_WebGeo.Models.Registo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Net;
using System.Net.Http;



namespace API_WebGeo.Controllers
{
    [EnableCors(origins: "http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]

    public class RegistoController : ApiController
    {
        private IRegistoRepository repository;

        public RegistoController() { }

        public RegistoController(IRegistoRepository repository)
        {
            this.repository = repository;
        }

        [Route("api/registar")]
        public IHttpActionResult Registar(Registo registo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                var existingRegisto = repository.GetByEmail(registo.Email);
                if (existingRegisto != null)
                {
                    return BadRequest("O email já está em uso.");
                }

                
                repository.Create(registo);

                
                var location = Url.Link("RegistarApi", new { id = registo.UtilizadorID });

                
                var response = new HttpResponseMessage(HttpStatusCode.Created);
                response.Headers.Location = new Uri(location);

                
                return ResponseMessage(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }




    }
}