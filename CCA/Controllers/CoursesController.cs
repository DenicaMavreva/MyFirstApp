using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels;
using CCA.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
        public IActionResult Fees()
        {
            return this.View();
        }
        public IActionResult Architecture()
        {
            return this.View();
        }
        public IActionResult CityDesign()
        {
            return this.View();
        }
        public IActionResult CeramicsAndGlass()
        {
            return this.View();
        }

        public IActionResult AllCourses()
        {
            var viewModel = new LoggedInViewCourses
            {
                Courses = this.dbContext.Courses.Select(c => new CourseIndexDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Credits = c.Credits,
                }).ToList()
            };
            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(p => p.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid course id");
            }
            else
            {
                return this.View(course);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult Create(CourseInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var course = new Courses
            {
                Title = model.Title,
                Description = model.Description,
                Credits = model.Credits
            };

            dbContext.Add(course);
            try
            {
                dbContext.SaveChanges();
                return this.RedirectToAction("Details", new {Id = course.Id});
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult Edit(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid product ID.");
            }

            var viewModel = new CourseInputViewModel
            {
                Title = course.Title,
                Description = course.Description,
                Credits = course.Credits,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult Edit(CourseInputViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid product ID.");
            }

            course.Title = model.Title;
            course.Credits = model.Credits;
            course.Description = model.Description;

            try
            {
                this.dbContext.SaveChanges();
                return this.RedirectToAction("Details", new {Id = id});
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult Delete(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid product ID.");
            }

            var viewModel = new CourseInputViewModel
            {
                Title = course.Title,
                Description = course.Description,
                Credits = course.Credits,
            };

            return this.View(viewModel);
        }

        [HttpPost("/courses/delete/{id}")]
        [Authorize(Roles = adminRole)]
        public IActionResult DoDelete(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return this.BadRequest("Invalid product ID.");
            }

            this.dbContext.Remove(course);

            try
            {
                this.dbContext.SaveChanges();
                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}