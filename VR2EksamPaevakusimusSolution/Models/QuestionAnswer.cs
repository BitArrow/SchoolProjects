using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionAnswer : BaseMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuestionAnswerId { get; set; }
        public Guid QuestionId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        public bool Locked { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
