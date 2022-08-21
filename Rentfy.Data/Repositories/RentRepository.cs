using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(RentfyContext context) : base(context) { }

        public async Task<Rent> GetById(long id)
        {
            return await _context.Rents
                .Include(x => x.Store)
                .Include(x => x.Status)
                .Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Rent rent)
        {
            await _context.AddAsync(rent);
        }

        public async Task Update(Rent rent)
        {
            await Task.Run(() => _context.Rents.Update(rent));
        }
    }
}
