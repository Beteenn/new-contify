using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IProductCategoryAppService
    {
        Task<Result<ProductCategoryViewModel>> GetProductCategoryById(long id);
        Task<Result<ProductCategoryViewModel>> CreateProductCategory(ProductCategoryDto categoryDto);
        Task<Result<ProductCategoryViewModel>> UpdateProductCategory(ProductCategoryDto categoryDto);
        Task<Result> DeleteProductCategoryById(long id);
    }
}
