using Rentfy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IObjetoTesteRepository : IBaseRepository<ObjetoTeste>
    {
        Task<ObjetoTeste> GetById(long id);
        Task AddObject(ObjetoTeste objeto);
        Task Update(ObjetoTeste objeto);
        Task DeleteObject(ObjetoTeste objeto);
        Task<IEnumerable<ObjetoTeste>> ListObjects();
    }
}
