using Rentfy.Domain.Entities;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task Add(Product product);
        Task<Product> GetById(long id);
        Task Update(Product productUpdate);
        Task Delete(Product product);
    }
}
