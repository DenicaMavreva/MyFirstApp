using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Students
{
    public class LoggedInViewStudent
    {
        public LoggedInViewStudent()
        {
            this.Student = new List<StudentIndexDto>();
        }

        public ICollection<StudentIndexDto> Student { get; set; }
    }
}
