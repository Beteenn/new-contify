using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface ITesteService
    {
        Task<DomainResult<ObjetoTeste>> GetById(int id);
        Task<DomainResult<IEnumerable<ObjetoTeste>>> ListObjects();
        Task<DomainResult<ObjetoTeste>> AddObject(ObjetoTeste objeto);
        Task<DomainResult<ObjetoTeste>> UpdateObject(ObjetoTeste objeto);
        Task DeleteObject(ObjetoTeste objeto);
    }
}
