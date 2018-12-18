using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCA.Models
{
    public class CCAUser : IdentityUser
    {
        public CCAUser()
        {
            this.Courses = new List<Courses>();
        }

        public string FullName { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }

    }
}
