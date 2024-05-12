using EntityLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsApp.Models;
using RepositoryLayer.Concrete;
using System.Security.Claims;

namespace NewsApp.Controllers.Security
{


    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginModel model)
        {
            //using (RepositoryContext c = new RepositoryContext())
            //{
            //    User user = await c.Users.FirstOrDefaultAsync(x => x.UserName == u.UserName && x.UserPassword == u.UserPassword);

            //    if (user != null)
            //    {
            //        var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, u.userName)
            //    };

            //        if (user.role == "Admin")
            //        {
            //            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            //        }
                  

            //        var useridentity = new ClaimsIdentity(claims, "a");
            //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

            //        await HttpContext.SignInAsync(principal);

            //        if (user.role == "Admin")
            //        {
            //            return RedirectToAction("Index","Haberler", "Admin");
            //        }
                    
            //        else
            //        {
            //            return RedirectToAction("ErrorPage", "Error");
            //        }
            //    }

            //    else
            //    {
            //        ModelState.AddModelError("", "Invalid username or password");
            //        return View();
            //    }
            //}
            if(ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);


                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Haberler", new {area = "Admin"});
                        
                    }
                    ModelState.AddModelError("Hata", "Invalid username or password.");
                }
            }
            return View();
        }
    }
}
