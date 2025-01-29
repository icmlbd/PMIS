using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PMIS.WebApp.Models.ViewModels;
using System.Security.Claims;

namespace PMIS.WebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            string userName = "shirajul.mamun@gmail.com";
            string password = "Test123!";

            if (model.UserName == userName && model.Password == password) {
                //login mechanism //authenticate process for the user

                Claim userNameClaim = new Claim(ClaimTypes.Name, model.UserName);
                Claim userRoleClaim = new Claim(ClaimTypes.Role, "Customer Manager"); 

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(userNameClaim);
                identity.AddClaim(userRoleClaim);

                var principal = new ClaimsPrincipal(identity);
                

                await HttpContext.SignInAsync(principal);

                return LocalRedirect(returnUrl);

                //HttpContext.User.Identity.; 

            
                //redirect the user to the return url 


            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("Login");

            
        }
    }
}
