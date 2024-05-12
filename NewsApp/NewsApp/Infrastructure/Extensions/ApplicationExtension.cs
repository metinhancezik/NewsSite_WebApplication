using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace NewsApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string AdminPassword = "Masscomedya!42";

            //UserManager
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser(adminUser);

                var result = await userManager.CreateAsync(user, AdminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                    );
                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin");
            }
        }
    }
    
}