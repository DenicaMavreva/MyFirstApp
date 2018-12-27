using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Users
{
    public class AllUsersViewModel
    {
        public AllUsersViewModel()
        {
            this.Users = new List<AllUsersDto>();
        }

        public ICollection<AllUsersDto> Users { get; set; }
    }
}
