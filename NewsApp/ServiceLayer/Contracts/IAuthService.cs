using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityResult> CreateUser(IdentityUser user, String password);
        Task<IdentityUser> GetOneUser(string userName);
        Task Update(IdentityUser user);
    }
}
