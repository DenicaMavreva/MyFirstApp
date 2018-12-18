using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
   public class Subjects
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }


    }
}
