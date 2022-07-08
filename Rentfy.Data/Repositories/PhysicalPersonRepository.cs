using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class PhysicalPersonRepository : BaseRepository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(RentfyContext context) : base(context) { }

        public async Task AddPerson(PhysicalPerson person)
        {
            await _context.AddAsync(person);
        }
    }
}
