using Rentfy.Domain.Entities;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IPhysicalPersonRepository : IBaseRepository<PhysicalPerson>
    {
        Task AddPerson(PhysicalPerson person);
    }
}
