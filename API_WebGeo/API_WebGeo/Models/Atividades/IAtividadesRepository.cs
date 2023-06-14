using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WebGeo.Models.Atividades
{
    public interface IAtividadesRepository
    {
        Task<Atividades> GetAtividades(int AtividadeID);

        Task<bool> DeleteAtividade(int AtividadeID);

        void Create(Atividades atividade);

    }
}
