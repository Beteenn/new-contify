using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(RentfyContext context) : base(context) { }

        public async Task<Store> GetById(long id)
        {
            return await _context.Stores
                .Include(x => x.Products)
                .Include(x => x.LegalPerson)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Store store)
        {
            await _context.AddAsync(store);
        }

        public async Task Update(Store storeUpdate)
        {
            await Task.Run(() => _context.Stores.Update(storeUpdate));
        }

        public async Task Delete(Store store)
        {
            await Task.Run(() => _context.Stores.Remove(store));
        }
    }
}
