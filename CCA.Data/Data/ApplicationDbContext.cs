using System;
using System.Collections.Generic;
using System.Text;
using CCA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CCA.Data
{
    public class ApplicationDbContext : IdentityDbContext<CCAUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Courses> Courses { get; set; }

        public DbSet<Education> Education { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subjects> Subjectses { get; set; }
    }
}
