using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IProductCategoryService
    {
        Task<DomainResult<ProductCategory>> Create(ProductCategory category);
        Task<DomainResult<ProductCategory>> GetById(long id);
        Task<DomainResult<ProductCategory>> Update(long id, ProductCategory category);
        Task<DomainResult> DeleteById(long id);
    }
}
