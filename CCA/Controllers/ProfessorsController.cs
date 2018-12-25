using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Data;
using CCA.Models;
using CCA.ViewModels.Professors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Controllers
{
    public class ProfessorsController : Controller
    {
        private const string adminRole = "Admin";
        private ApplicationDbContext dbContext;

        public ProfessorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult AllProfessors()
        {
            var viewModel = new LoggedInViewProfessor
            {
                Professors = this.dbContext.Professors.Select(p => new ProfessorIndexDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ScienceDegree = p.ScienceDegree,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email,
                }).ToList()
            };
            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var professor = dbContext.Professors.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid professor id");
            }
            else
            {
                return this.View(professor);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult CreateProfessor()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult CreateProfessor(ProfessorInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var professor = new Professor
            {
                FullName = model.FullName,
                ScienceDegree = model.ScienceDegree,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            dbContext.Add(professor);
            try
            {
                dbContext.SaveChanges();
                return this.RedirectToAction("Details", new { Id = professor.Id });
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult EditProfessor(int id)
        {
            var professor = dbContext.Professors.FirstOrDefault(c => c.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid professor ID.");
            }

            var viewModel = new ProfessorInputViewModel
            {
                FullName = professor.FullName,
                ScienceDegree = professor.ScienceDegree,
                PhoneNumber = professor.PhoneNumber,
                Email = professor.Email
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = adminRole)]
        public IActionResult EditProfessor(ProfessorInputViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var professor = dbContext.Professors.FirstOrDefault(c => c.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid professor ID.");
            }

            professor.FullName = model.FullName;
            professor.ScienceDegree = model.ScienceDegree;
            professor.PhoneNumber = model.PhoneNumber;
            professor.Email = professor.Email;

            try
            {
                this.dbContext.SaveChanges();
                return this.RedirectToAction("Details", new { Id = id });
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [Authorize(Roles = adminRole)]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = dbContext.Professors.FirstOrDefault(c => c.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid professor ID.");
            }

            var viewModel = new ProfessorInputViewModel
            {
                FullName = professor.FullName,
                ScienceDegree = professor.ScienceDegree,
                PhoneNumber = professor.PhoneNumber,
                Email = professor.Email
            };

            return this.View(viewModel);
        }

        [HttpPost("/professors/delete/{id}")]
        [Authorize(Roles = adminRole)]
        public IActionResult DoDeleteProfessor(int id)
        {
            var professor = dbContext.Professors.FirstOrDefault(c => c.Id == id);
            if (professor == null)
            {
                return this.BadRequest("Invalid product ID.");
            }

            this.dbContext.Remove(professor);

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