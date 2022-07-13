using Rentfy.Data.Configuration;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.InterfacesRepository;

namespace Rentfy.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RentfyContext context) : base(context) { }
    }
}
