using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [MaxLength(64)]
        public string SubjectName { get; set; }

        public virtual ICollection<Grades> Grades { get; set; }
    }
}
