using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
    public class Student
    {
        public Student()
        {
            this.Subjects = new List<Subjects>();
            this.Professors = new List<Professor>();
            this.Enrollments = new List<Enrollment>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Faculty { get; set; }

        public int FacultyNumber { get; set; }

        public string QualificationDegrees { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; }

        public virtual ICollection<Professor> Professors { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}
