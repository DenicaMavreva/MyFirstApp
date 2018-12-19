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

        public IActionResult ArtAndDesign()
        {
            return this.View();
        }

        public IActionResult Details(int id)
        {
            var product = dbContext.Courses.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return this.BadRequest("Invalid product id");
            }

            return this.View(product);
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
            };

            dbContext.Add(course);
            try
            {
                dbContext.SaveChanges();
                return this.RedirectToAction("Details", new { Id = course.Id });
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}