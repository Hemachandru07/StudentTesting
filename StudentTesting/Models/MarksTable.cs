using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Models
{
    public class MarksTable
    {
        [Key]
        public int MarksId { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject1 { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject2 { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject3 { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject4 { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject5 { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(3)]
        public int Subject6 { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Studenttbl studenttbl { get; set; } 
    }
}
