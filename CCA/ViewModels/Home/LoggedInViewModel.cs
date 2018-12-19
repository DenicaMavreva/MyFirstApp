using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCA.Models;

namespace CCA.ViewModels.Home
{
    public class LoggedInViewModel
    {
        public LoggedInViewModel()
        {
            this.Courses = new List<CourseIndexDto>();
        }

        public ICollection<CourseIndexDto> Courses { get; set; }


    }
}
