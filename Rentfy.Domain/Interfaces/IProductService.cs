using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IProductService
    {
        Task<DomainResult<Product>> Create(Product product);
        Task<DomainResult<Product>> GetById(long id);
        Task<DomainResult<Product>> Update(long id, Product productUpdate);
        Task<DomainResult> DeleteById(long id);
    }
}
