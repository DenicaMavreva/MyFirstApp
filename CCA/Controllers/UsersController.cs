using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Controllers
{
    public class UsersController : Controller
    {
        private const string adminRole = "Admin";
        private ApplicationDbContext dbcontext;
        private UserManager<CCAUser> userManager;

        public UsersController(ApplicationDbContext dbcontext, UserManager<CCAUser> userManager)
        {
            this.dbcontext = dbcontext;
            this.userManager = userManager;
        }

        public IActionResult UserDetails(string id)
        {
            var user = dbcontext.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                return this.BadRequest("Invalid user id");
            }
            else
            {
                return this.View(user);
            }
        }

        public IActionResult AllUsers()
        {
            var viewModel = new AllUsersViewModel
            {
                Users = userManager.Users.Select(u =>
                    new AllUsersDto
                    {
                        Id = u.Id,
                        Username = u.UserName,
                        Email = u.Email,
                    }).ToList()
            };

            return View("AllUsers", viewModel);
        }

        [Authorize(Roles = adminRole)]
        public IActionResult DeleteUser(string id)
        {
            var user = dbcontext.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return this.BadRequest("Invalid user ID.");
            }

            var viewModel = new UsersInputViewModel
            {
                FullName = user.FullName,
                Email = user.Email
            };

            return this.View(viewModel);
        }

        [HttpPost("/users/delete/{id}")]
        [Authorize(Roles = adminRole)]
        public IActionResult DoDeleteUser(string id)
        {
            var user = dbcontext.Users.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return this.BadRequest("Invalid user ID.");
            }

            this.dbcontext.Remove(user);

            try
            {
                this.dbcontext.SaveChanges();
                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }


    }
}