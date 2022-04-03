using Contify.Application.DTO;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;
using System.Threading.Tasks;

namespace Contify.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<Result<UserViewModel>> CreateUser(UserDto userDto);
        Task<Result<TokenViewModel>> Login(LoginDto loginDto);
    }
}
