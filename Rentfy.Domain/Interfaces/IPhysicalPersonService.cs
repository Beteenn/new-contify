using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IPhysicalPersonService
    {
        Task<DomainResult<PhysicalPerson>> CreatePhysicalPerson(PhysicalPerson person);
    }
}
