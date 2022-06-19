using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IUserService
    {
        Task<DomainResult<User>> CreateUser(User user, string password);
        Task<DomainResult<User>> GetByLogin(string login);
        Task<DomainResult<User>> ValidatePassword(User user, string password);
    }
}
