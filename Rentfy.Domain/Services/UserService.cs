using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<DomainResult<User>> CreateUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) return new DomainResult<User>().AddErrorMessage("Create user error.");

            return new DomainResult<User>(user);
        }

        public async Task<DomainResult<User>> GetByLogin(string login)
        {
            var user = await _userManager.FindByNameAsync(login);

            if (user == null) return new DomainResult<User>().AddErrorMessage("User not found.");

            return new DomainResult<User>(user);
        }

        public async Task<DomainResult<User>> ValidatePassword(User user, string password)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!signInResult.Succeeded) return new DomainResult<User>().AddErrorMessage("User or password invalid.");

            return new DomainResult<User>(user);
        }
    }
}
