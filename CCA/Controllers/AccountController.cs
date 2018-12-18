using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.Services.Interfaces;
using CCA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CCA.Controllers
{
    
    public class AccountController : Controller
    {
        private SignInManager<CCAUser> signIn;
        private IAccountService accountService;
        private ApplicationDbContext dbContext;

        public AccountController(SignInManager<CCAUser> signIn,ApplicationDbContext dbContext, IAccountService accountService)
        {
            this.signIn = signIn;
            this.accountService = accountService;
            this.dbContext = dbContext;
        }

        [Authorize]
        public IActionResult AccessDenied()
        {
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isRegestered = this.accountService.Register(signIn, model);
                if (isRegestered)
                {
                    return this.Redirect("/home/index");
                }
            }

            return this.View(model);
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loggedIn = this.accountService.Login(signIn, model);
                if (loggedIn)
                {
                    return this.Redirect("/home/index");
                }
            }
            return this.View(model);
        }

       [Authorize]
        public IActionResult Logout()
        {
            this.signIn.SignOutAsync().Wait();
            return this.RedirectToAction("Index", "Home");
        }
    }
}