using AmigosRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmigosRESTAPI.Controllers
{
    public class LocaisController
    {
        private ILocaisRepository repository;

        public LocaisController() { }
        public LocaisController(ILocaisRepository repository)
        {
            this.repository = repository;
        }

        [Route("api/locais")]
        public IEnumerable<Locais> GetAll()
        {
            return repository.GetAll();
        }
    }
}