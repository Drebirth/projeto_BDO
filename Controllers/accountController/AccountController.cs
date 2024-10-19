using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projetoBDO.Models;

namespace projetoBDO.Controllers.accountController
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }   

         public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser{
                    UserName = model.Usuario
                };

                var result = await userManager.CreateAsync(user, model.Password);

                 if (result.Succeeded)
                 {
                     await signInManager.SignInAsync(user, isPersistent: false);
                     return RedirectToAction("login", "account");
                 }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(login.Usuario, 
                    login.Password,login.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("index","local");
            }
                ModelState.AddModelError(string.Empty,"Login inválido");
            }
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }
        
    }
}