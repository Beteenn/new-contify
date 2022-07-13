using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<Result<ProductViewModel>> GetProductById(long id);
        Task<Result<ProductViewModel>> CreateProduct(ProductDto productDto);
        Task<Result<ProductViewModel>> UpdateProduct(ProductDto productDto);
        Task<Result> DeleteProductById(long id);
    }
}
