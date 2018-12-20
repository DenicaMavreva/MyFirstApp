using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCA.ViewModels.Professors
{
    public class LoggedInViewProfessor
    {
        public LoggedInViewProfessor()
        {
            this.Professors = new List<ProfessorIndexDto>();
        }

        public ICollection<ProfessorIndexDto> Professors { get; set; }
    }
}
