using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IPhysicalPersonService
    {
        Task<DomainResult<PhysicalPerson>> CreatePhysicalPerson(PhysicalPerson person);
        Task<DomainResult<PhysicalPerson>> GetById(long id);
        Task<DomainResult<PhysicalPerson>> Update(long id, PhysicalPerson personUpdate);
        Task<DomainResult> DeleteById(long id);
    }
}
