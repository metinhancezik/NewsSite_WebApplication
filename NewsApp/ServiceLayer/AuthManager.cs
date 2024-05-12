using Microsoft.AspNetCore.Identity;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IEnumerable<IdentityRole> roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(IdentityUser user,String password)
        {

            //var result = await _userManager.CreateAsync(user, userDto.Password);
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
            
            return result;
        }

        

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }
        
        public async Task<IdentityUser> GetOneUser(string userName)
        {
            return  await _userManager.FindByNameAsync(userName);
        }

        public async Task Update(IdentityUser user)
        {
            return;
        }
    }
}