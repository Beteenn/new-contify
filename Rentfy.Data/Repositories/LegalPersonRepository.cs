using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class LegalPersonRepository : BaseRepository<LegalPerson>, ILegalPersonRepository
    {
        public LegalPersonRepository(RentfyContext context) : base(context) { }

        public async Task<LegalPerson> GetById(long id)
        {
            return await _context.LegalPeople
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddPerson(LegalPerson person)
        {
            await _context.AddAsync(person);
        }

        public async Task Update(LegalPerson personUpdate)
        {
            await Task.Run(() => _context.LegalPeople.Update(personUpdate));
        }

        public async Task Delete(LegalPerson person)
        {
            await Task.Run(() => _context.LegalPeople.Remove(person));
        }
    }
}
