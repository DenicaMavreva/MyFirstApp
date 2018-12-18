using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
   public class Courses
    {
        public Courses()
        {
            this.Students = new List<Student>();
            this.Enrollments = new List<Enrollment>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int UserId { get; set; }
        public CCAUser User { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
