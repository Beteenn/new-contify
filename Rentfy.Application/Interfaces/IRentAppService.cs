using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IRentAppService
    {
        Task<Result<RentViewModel>> GetRentById(long id);
        Task<Result<RentViewModel>> CreateRent(RentDto rentDto);
    }
}
