using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Students
{
    public class StudentInputViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
