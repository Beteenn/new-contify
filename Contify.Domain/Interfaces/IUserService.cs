using Contify.Domain.Entities.Identity;
using Contify.Domain.SeedWork;
using System.Threading.Tasks;

namespace Contify.Domain.Interfaces
{
    public interface IUserService
    {
        Task<DomainResult<User>> CreateUser(User user, string password);
        Task<DomainResult<User>> GetByLogin(string login);
        Task<DomainResult<User>> ValidatePassword(User user, string password);
    }
}
