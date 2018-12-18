using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
    public class Professor
    {
        public Professor()
        {
            this.Courses = new List<Courses>();
            this.Subjects = new List<Subjects>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string ScienceDegree { get; set; }

        public int PhoneNumber { get; set; }

        public string Cabinet { get; set; }

        public string Email { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }

        public virtual ICollection<Subjects> Subjects { get; set; }

    }
}
