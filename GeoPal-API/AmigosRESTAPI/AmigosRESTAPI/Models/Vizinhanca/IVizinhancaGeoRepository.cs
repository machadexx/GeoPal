using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Vizinhanca
{
    public interface IVizinhancaGeoRepository
    {
        IEnumerable<VizinhancaGeo> GetAll();
    }
}