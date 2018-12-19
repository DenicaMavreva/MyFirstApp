using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels;
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
            var course = dbContext.Courses.FirstOrDefault(p => p.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid product id");
            }

            return this.View(course);
        }

        [Authorize(Roles = adminRole)]
        public IActionResult Create()
        {
            return this.View();
        }


    }
}