using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Models
{
    public class Marks
    {

        [Key]
        public int MarksId { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0,100,ErrorMessage ="Enter Valid Marks in Range 0-100")]
        public int Subject1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        public int Subject2 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        public int Subject3 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        public int Subject4 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        public int Subject5 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        public int Subject6 { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Studenttbl Studentid { get; set; }



    }


}

