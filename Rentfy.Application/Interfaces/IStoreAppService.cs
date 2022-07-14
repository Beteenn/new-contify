using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IStoreAppService
    {
        Task<Result<StoreViewModel>> GetStoreById(long id);
        Task<Result<StoreViewModel>> CreateStore(StoreDto storeDto);
        Task<Result<StoreViewModel>> UpdateStore(StoreDto storeDto);
        Task<Result> DeleteStoreById(long id);
    }
}
