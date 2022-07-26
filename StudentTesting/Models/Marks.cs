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
        [Display(Name = "English")]
        public int Subject1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        [Display(Name = "Tamil")]
        public int Subject2 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        [Display(Name = "Maths")]
        public int Subject3 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        [Display(Name = "Science")]
        public int Subject4 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        [Display(Name = "Social")]
        public int Subject5 { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, 100, ErrorMessage = "Enter Valid Marks in Range 0-100")]
        [Display(Name = "Hindi")]
        public int Subject6 { get; set; }

        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Studenttbl Studentid { get; set; }



    }


}

