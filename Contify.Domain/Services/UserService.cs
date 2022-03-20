using Contify.Domain.Entities.Identity;
using Contify.Domain.Interfaces;
using Contify.Domain.InterfacesRepository;
using Contify.Domain.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Contify.Domain.Services
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
    }
}
