using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosRESTAPI.Models {
    public interface IAmigoRepository {
        IEnumerable<Amigo> GetAll();
    }
}
