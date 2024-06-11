using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MiniProject_IT_DIV.Models.DBmodels;
using MiniProject_IT_DIV.Models;
using MiniProject_IT_DIV.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MiniProject_IT_DIV.Controllers


{
    public class AuthController : Controller
    {
        private readonly Db_Cntx db_Cntx;

        public AuthController(Db_Cntx db_Cntx)
        {
            this.db_Cntx = db_Cntx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel loginUser)
        {
            var user = await db_Cntx.Persons.FirstOrDefaultAsync(p => p.Email == loginUser.Email && p.Password == loginUser.Password);
            if (user != null) {
                List<Claim> claims = new () { 
                    new Claim(ClaimTypes.NameIdentifier, user.Email)
                };
                ClaimsIdentity claimsIdentity = new (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new (claimsIdentity);

                AuthenticationProperties properties = new () { 
                    AllowRefresh = true,
                    IsPersistent = loginUser.KeepLoggedIn,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
                ViewBag.Username = user.Name;
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewData["ValidateMessage"] = "wrong email or pass";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserAddViewModel addUser)
        {
            Person user = new ()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
            };

            await db_Cntx.Persons.AddAsync(user);
            await db_Cntx.SaveChangesAsync();
            return RedirectToAction("Login");
        }
    }
}
