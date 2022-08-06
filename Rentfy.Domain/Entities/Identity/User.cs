using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Rentfy.Domain.Entities.Identity
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        public ICollection<Rent> Rents { get; private set; }

        public User() { }

        public User(string email, string firstName, string lastName, string userName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }
    }
}
