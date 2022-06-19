using Rentfy.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> CreateToken(User user);
    }
}
