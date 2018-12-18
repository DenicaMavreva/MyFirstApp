using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CCA.Models;

namespace CCA.ViewModels.Courses
{
    public class CoursesInputViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(350, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        public string Description { get; set; }

        [Required]
        public Professor Professor { get; set; }

        [Required]
        public int Credits { get; set; }

    }
}
