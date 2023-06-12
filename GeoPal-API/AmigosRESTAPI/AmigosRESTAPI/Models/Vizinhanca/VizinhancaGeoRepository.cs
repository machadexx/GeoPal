using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Vizinhanca
{
    public class VizinhancaGeoRepository : IVizinhancaGeoRepository
    {
        public IEnumerable<VizinhancaGeo> GetAll()
        {
            //mockVizinhancaGeo
            return new VizinhancaGeo[] {
                new VizinhancaGeo {Id = 1, UtilizadorId = 1, Descricao = "desc", Nome="zeferino vizinhança"}
            };
        }
    }
}