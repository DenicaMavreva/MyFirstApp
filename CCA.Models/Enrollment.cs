using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
    public class Enrollment
    {
        public int  Id { get; set; }
        
        public string Bachelor { get; set; }

        public string Master { get; set; }

        public string Doctor { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }

    }
}
