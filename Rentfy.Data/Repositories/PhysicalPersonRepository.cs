using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class PhysicalPersonRepository : BaseRepository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(RentfyContext context) : base(context) { }

        public async Task<PhysicalPerson> GetById(long id)
        {
            return await _context.PhysicalPeople
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddPerson(PhysicalPerson person)
        {
            await _context.AddAsync(person);
        }

        public async Task Update(PhysicalPerson personUpdate)
        {
            await Task.Run(() => _context.PhysicalPeople.Update(personUpdate));
        }

        public async Task Delete(PhysicalPerson person)
        {
            await Task.Run(() => _context.PhysicalPeople.Remove(person));
        }
    }
}
