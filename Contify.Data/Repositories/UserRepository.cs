using Contify.Data.Configuration;
using Contify.Domain.Entities.Identity;
using Contify.Domain.InterfacesRepository;

namespace Contify.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ContifyContext context) : base(context) { }
    }
}
