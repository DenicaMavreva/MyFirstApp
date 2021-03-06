﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
    public class Student
    {
        public Student()
        {
            this.Enrollments = new List<Enrollment>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Faculty { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
