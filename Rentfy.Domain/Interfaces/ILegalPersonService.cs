using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface ILegalPersonService
    {
        Task<DomainResult<LegalPerson>> Create(LegalPerson person);
        Task<DomainResult<LegalPerson>> GetById(long id);
        Task<DomainResult<LegalPerson>> Update(long id, LegalPerson personUpdate);
        Task<DomainResult> DeleteById(long id);
    }
}
