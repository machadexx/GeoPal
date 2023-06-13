using API_WebGeo.Models.Login;
using API_WebGeo.Models.Utilizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace API_WebGeo.Controllers
{
    [EnableCors(origins: "http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UtilizadorController : ApiController
    {
        private IUtilizadorRepository repository;

        public UtilizadorController() { }

        public UtilizadorController(IUtilizadorRepository repository)
        {
            this.repository = repository;
        }


        [Route("api/utilizador")]
        public async Task<IHttpActionResult> GetUserByLogin([FromUri] string email, [FromUri] string password)
        {
            try
            {
                Utilizador utilizador = await repository.GetUserByLogin(email, password);

                if (utilizador != null)
                {
                    return Ok(utilizador);
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

        [Route("api/delete/{id}")]        
        public async Task<IHttpActionResult> DeleteUtilizador(int id)
        {
            try
            {
                bool result = await repository.DeleteUtilizador(id);

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



    }
}