using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Atividades
{
    public interface IAtividadesRepository
    {
        IEnumerable<Atividades> GetAll();
        IEnumerable<Atividades> GetAtividade();
    }
}