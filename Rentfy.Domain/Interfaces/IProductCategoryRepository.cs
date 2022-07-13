using Rentfy.Domain.Entities;
using Rentfy.Domain.InterfacesRepository;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        Task Add(ProductCategory category);
        Task<ProductCategory> GetById(long id);
        Task Update(ProductCategory categoryUpdate);
        Task Delete(ProductCategory category);
    }
}
