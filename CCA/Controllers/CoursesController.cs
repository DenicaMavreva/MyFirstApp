using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels.Courses;
using CCA.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Controllers
{
    public class CoursesController : Controller
    {
        private const string adminRole = "Admin";

        private ApplicationDbContext dbContext;

        public CoursesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Courses()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var viewModel = new LoggedInViewModel
                {
                    //Courses = dbContext.Courses.Select(p =>
                    //    new CourseIndexDto
                    //    {
                    //        Id = p.Id,
                    //        Title = p.Title,
                    //        Description = p.Description.Substring(0, 37) + "...", //shortens desc if it is too long
                    //    }).ToList()
                };
                return this.View("Courses", viewModel);
            }
            else
            {
                return View();

            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult Create(CoursesInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var course = new Courses
            {
                Title = model.Title,
                Description = model.Description,
                Professor = model.Professor
            };

            dbContext.Add(course);
            try
            {
                dbContext.SaveChanges();
                return this.RedirectToAction("Course", "Create");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}