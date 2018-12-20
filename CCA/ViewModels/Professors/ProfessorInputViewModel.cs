using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Professors
{
    public class ProfessorInputViewModel
    {

        [Required]
        public string FullName { get; set; }

        [Required]
        public string ScienceDegree { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
