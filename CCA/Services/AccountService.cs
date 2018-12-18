using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CCA.Models;
using CCA.Services.Interfaces;
using CCA.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CCA.Services
{
    public class AccountService : IAccountService
    {
        public bool Register(SignInManager<CCAUser> signIn, RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }
            var user = new CCAUser
            {
                Email = model.Email,
                FullName = model.FullName,
                UserName = model.Username,
            };
            var result = signIn.UserManager.CreateAsync(user, model.Password)
                .GetAwaiter()
                .GetResult()
                .Succeeded;

            if (result && signIn.UserManager.Users.Count() == 1)
            {
                this.SetRole(signIn, model, "Admin");
            }
            return result;
        }

        public bool Login(SignInManager<CCAUser> signIn, LoginViewModel model)
        {
           
            var user = signIn.UserManager.FindByNameAsync(model.Username)
                .GetAwaiter()
                .GetResult();
            if (user == null)
            {
                return false;
            }
            var result = signIn.PasswordSignInAsync(user, model.Password, model.RememberMe, false)
                .GetAwaiter()
                .GetResult()
                .Succeeded;
            return result;
        }

        public bool Logout(SignInManager<CCAUser> signIn, ClaimsPrincipal model)
        {
            signIn.SignOutAsync()
                .GetAwaiter()
                .GetResult();
            //  var user = signIn.UserManager.FindByNameAsync(model.Username);
            //   signIn.IsSignedIn(this.User);
            return true;
        }

        bool SetRole(SignInManager<CCAUser> signIn, RegisterViewModel model, string role)
        {
            var user = signIn.UserManager.FindByNameAsync(model.Username)
                .GetAwaiter()
                .GetResult();
            var added = signIn.UserManager.AddToRoleAsync(user, role)
                .GetAwaiter()
                .GetResult()
                .Succeeded;
            return added;
        }
    }
}
