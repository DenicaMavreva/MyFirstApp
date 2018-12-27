using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Controllers
{
    public class StudentController : Controller
    {
        private const string adminRole = "Admin";
        private ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult AllStudents()
        {
            var viewModel = new LoggedInViewStudent
            {
                Student = this.dbContext.Students.Select(p => new StudentIndexDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    EnrollmentDate = p.EnrollmentDate,
                    Email = p.Email,
                }).ToList()
            };
            return this.View(viewModel);
        }
        public IActionResult AllStudentsUserView()
        {
            var viewModel = new LoggedInViewStudent
            {
                Student = this.dbContext.Students.Select(p => new StudentIndexDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    EnrollmentDate = p.EnrollmentDate,
                    Email = p.Email,
                }).ToList()
            };
            return this.View(viewModel);
        }

        public IActionResult DetailsStudent(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student == null)
            {
                return this.BadRequest("Invalid student id");
            }
            else
            {
                return this.View(student);
            }
        }



        [Authorize(Roles = adminRole)]
        public IActionResult CreateStudent()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult CreateStudent(StudentInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var student = new Student
            {
                FullName = model.FullName,
                Faculty = model.Faculty,
                EnrollmentDate = model.EnrollmentDate,
                Email = model.Email
            };

            dbContext.Add(student);
            try
            {
                dbContext.SaveChanges();
                return this.RedirectToAction("DetailsStudent", new { Id = student.Id });
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult EditStudent(int id)
        {
            var student = dbContext.Students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return this.BadRequest("Invalid student ID.");
            }

            var viewModel = new StudentInputViewModel
            {
                FullName = student.FullName,
                Faculty = student.Faculty,
                EnrollmentDate = student.EnrollmentDate,
                Email = student.Email
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult EditStudent(StudentInputViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var student = dbContext.Students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return this.BadRequest("Invalid professor ID.");
            }

            student.FullName = model.FullName;
            student.Faculty = model.Faculty;
            student.EnrollmentDate = model.EnrollmentDate;
            student.Email = model.Email;

            try
            {
                this.dbContext.SaveChanges();
                return this.RedirectToAction("DetailsStudent", new { Id = id });
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult DeleteStudent(int id)
        {
            var professor = dbContext.Students.FirstOrDefault(c => c.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid student ID.");
            }

            var viewModel = new StudentInputViewModel
            {
                FullName = professor.FullName,
                Faculty = professor.Faculty,
                EnrollmentDate = professor.EnrollmentDate,
                Email = professor.Email
            };

            return this.View(viewModel);
        }

        [HttpPost("/students/delete/{id}")]
        [Authorize(Roles = adminRole)]
        public IActionResult DoDeleteStudent(int id)
        {
            var student = dbContext.Students.FirstOrDefault(c => c.Id == id);
            if (student == null)
            {
                return this.BadRequest("Invalid student ID.");
            }

            this.dbContext.Remove(student);

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
