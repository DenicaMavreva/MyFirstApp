using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Students
{
    public class StudentIndexDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Faculty { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Email { get; set; }
    }
}
