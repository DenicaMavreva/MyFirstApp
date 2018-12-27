using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Users
{
    public class UsersInputViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
