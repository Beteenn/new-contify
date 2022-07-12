using Rentfy.Domain.Entities;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface ILegalPersonRepository : IBaseRepository<LegalPerson>
    {
        Task AddPerson(LegalPerson person);
        Task<LegalPerson> GetById(long id);
        Task Update(LegalPerson personUpdate);
        Task Delete(LegalPerson person);
    }
}
