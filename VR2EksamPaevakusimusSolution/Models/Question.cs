using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question : BaseMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuestionId { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Title { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
        public bool Visible { get; set; }
        public bool Published { get; set; }

        public bool Locked { get; set; }

        public virtual List<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();

    }
}
