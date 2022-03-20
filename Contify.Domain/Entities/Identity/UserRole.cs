using Microsoft.AspNetCore.Identity;

namespace Contify.Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<long>
    {
        public User User { get; private set; }

        public Role Role { get; private set; }

        public UserRole() { }
    }
}
