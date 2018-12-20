using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Course
{
    public class LoggedInViewCourses
    {
        public LoggedInViewCourses()
        {
            this.Courses = new List<CourseIndexDto>();
        }

        public ICollection<CourseIndexDto> Courses { get; set; }
    }
}
