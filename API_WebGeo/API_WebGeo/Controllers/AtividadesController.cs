using API_WebGeo.Models.Atividades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_WebGeo.Controllers
{
    [EnableCors(origins: "http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AtividadesController : ApiController
    {
        private IAtividadesRepository repository;

        public AtividadesController() { }

        public AtividadesController(IAtividadesRepository repository)
        {
            this.repository = repository;
        }

        [Route("api/atividade")]
        public async Task<IHttpActionResult> GetAtividades([FromUri] int ActividadeID)
        {
            try
            {
                Atividades atividades = await repository.GetAtividades(ActividadeID);

                if (ActividadeID != null)
                {
                    return Ok(atividades);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/atividade/delete/{AtividadeID}")]
        public async Task<IHttpActionResult> DeleteAtividade(int AtividadeID)
        {
            try
            {
                bool result = await repository.DeleteAtividade(AtividadeID);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [Route("api/atividade/registar")]
        public IHttpActionResult Registar(Atividades atividades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                repository.Create(atividades);


                var location = Url.Link("RegistarApi", new { id = atividades.AtividadeID });


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