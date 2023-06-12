using AmigosRESTAPI.Models.Vizinhanca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmigosRESTAPI.Models.Atividades
{
    public class AtividadesRepository : IAtividadesRepository
    {
        public IEnumerable<Atividades> GetAll()
        {
            //mockAtividades
            return new Atividades[] {
                new Atividades {Id = 1, VizinhancaId = 1, Nome = "atividade", Coordenadas = "123", Inicio = "132", Fim = "321", Localizacao = "asd"},
            };
        }
    }
}