using AmigosRESTAPI.Models.Vizinhanca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AmigosRESTAPI.Controllers
{
    [EnableCors(origins:"http://localhost,http://localhost:8100", headers: "*", methods: "*", SupportsCredentials = true)]
    public class VizinhancaGeoController : ApiController
    {
        private IVizinhancaGeoRepository repository;

        public VizinhancaGeoController() { }
        public VizinhancaGeoController(IVizinhancaGeoRepository repository)
        {
            this.repository = repository;
        }

        // GET:
        // exemplo http://localhost/AmigosRESTAPI/api/vizinhanca
        [Route("api/vizinhanca")]
        public IEnumerable<VizinhancaGeo> GetAll()
        {
            return repository.GetAll();
        }
    }
}