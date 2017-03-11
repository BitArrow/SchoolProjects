using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grades
    {
        public int GradesId { get; set; }

        public int Grade { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
