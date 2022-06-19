using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.Interfaces;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _tokenService;
        public UserAppService(IUserService userService, IAuthenticationService tokenService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<Result<UserViewModel>> CreateUser(UserDto userDto)
        {
            var user = new User(userDto.Email, userDto.FirstName, userDto.LastName, userDto.UserName);

            var result = await _userService.CreateUser(user, userDto.Password);

            return Mapper.Map<Result<UserViewModel>>(result);
        }

        public async Task<Result<TokenViewModel>> Login(LoginDto loginDto)
        {
            var userResult = await _userService.GetByLogin(loginDto.Login);

            if (!userResult.Success) return new Result<TokenViewModel>().AddErrorMessage(userResult.ErrorMessages);

            var validatePass = await _userService.ValidatePassword(userResult.Data, loginDto.Password);

            if (!validatePass.Success) return new Result<TokenViewModel>().AddErrorMessage(validatePass.ErrorMessages);

            var token = new TokenViewModel
            {
                Name = userResult.Data.FirstName,
                Token = await _tokenService.CreateToken(userResult.Data)
            };

            return new Result<TokenViewModel>(token);
        }
    }
}
