using Rentfy.Application.DTO;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<Result<UserViewModel>> CreateUser(UserDto userDto);
        Task<Result<TokenViewModel>> Login(LoginDto loginDto);
    }
}
