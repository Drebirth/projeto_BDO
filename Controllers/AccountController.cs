using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using projetoBDO.Context;
using projetoBDO.Models;
using projetoBDO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projetoBDO.Controllers.accountController
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly BdoContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager,BdoContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _context = context;
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
                if (!await roleManager.RoleExistsAsync("ADMIN"))
                {
                    await roleManager.CreateAsync(new IdentityRole("ADMIN"));
                }
                if (!await roleManager.RoleExistsAsync("USER"))
                {
                    await roleManager.CreateAsync(new IdentityRole("USER"));
                }

                var user = new IdentityUser{
                    UserName = model.NomeDeFamilia,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                 if (result.Succeeded)
                 {
                     await signInManager.SignInAsync(user, isPersistent: false);
                    //await userManager.AddClaimAsync(user, new Claim("PERMISSAO","ADMIN"));
                    await userManager.AddToRoleAsync(user, "USER");
                    
                    return RedirectToAction("Index", "Personagem");
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
                var result = await signInManager.PasswordSignInAsync(login.NomeDefamilia, 
                    login.Password,login.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("index","Mapa");
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