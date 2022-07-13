using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(RentfyContext context) : base(context) { }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Product product)
        {
            await _context.AddAsync(product);
        }

        public async Task Update(Product productUpdate)
        {
            await Task.Run(() => _context.Products.Update(productUpdate));
        }

        public async Task Delete(Product product)
        {
            await Task.Run(() => _context.Products.Remove(product));
        }
    }
}
