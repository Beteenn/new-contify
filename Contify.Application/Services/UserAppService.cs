using AutoMapper;
using Contify.Application.DTO;
using Contify.Application.Interfaces;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;
using Contify.Domain.Entities.Identity;
using Contify.Domain.Interfaces;
using System.Threading.Tasks;

namespace Contify.Application.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        public async Task<Result<UserViewModel>> CreateUser(UserDto userDto)
        {
            var user = new User(userDto.Email, userDto.FirstName, userDto.LastName, userDto.UserName);

            var result = await _userService.CreateUser(user, userDto.Password);

            return Mapper.Map<Result<UserViewModel>>(result);
        }
    }
}
