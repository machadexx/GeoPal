using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models
{
    public interface ILocaisRepository
    {
        IEnumerable<Locais> GetAll();
    }
}