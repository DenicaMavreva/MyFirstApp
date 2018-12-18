using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CCA.Models;
using CCA.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CCA.Services.Interfaces
{
    public interface IAccountService
    {
        bool Register(SignInManager<CCAUser> signIn, RegisterViewModel model);

        bool Login(SignInManager<CCAUser> signIn, LoginViewModel model);

        bool Logout(SignInManager<CCAUser> signIn, ClaimsPrincipal model);

    }
}
