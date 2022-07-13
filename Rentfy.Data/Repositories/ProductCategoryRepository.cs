using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System.Threading.Tasks;

namespace Rentfy.Data.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RentfyContext context) : base(context) { }

        public async Task Add(ProductCategory category)
        {
            await _context.AddAsync(category);
        }

        public async Task Delete(ProductCategory category)
        {
            await Task.Run(() => _context.ProductCategories.Remove(category));
        }

        public async Task<ProductCategory> GetById(long id)
        {
            return await _context.ProductCategories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(ProductCategory categoryUpdate)
        {
            await Task.Run(() => _context.ProductCategories.Update(categoryUpdate));
        }
    }
}
