using API_WebGeo.Models.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_WebGeo.Controllers
{
    public class NotificacoesController : ApiController
    {
        private INotificacoesRepository repository;

        public NotificacoesController() { }

        public NotificacoesController(INotificacoesRepository repository)
        {
            this.repository = repository;
        }

        [Route("api/notificacoes")]
        public async Task<IHttpActionResult> GetNotificacoes([FromUri] int NotificacaoID)
        {
            try
            {
                Notificacoes notificacoes = await repository.GetNotificacoes(NotificacaoID);

                if (NotificacaoID != null)
                {
                    return Ok(notificacoes);
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

        [Route("api/notificacoes/delete/{AtividadeID}")]
        public async Task<IHttpActionResult> DeleteNotificacoes(int NotificacaoID)
        {
            try
            {
                bool result = await repository.DeleteNotificacoes(NotificacaoID);

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