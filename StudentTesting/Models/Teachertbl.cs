using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Models
{
    public class Teachertbl
    {
        
        [Key]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "*")]
        public string FacultyName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Department { get; set; }

        [Required(ErrorMessage = "Minimum 8 Characters required")]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password does Not Match")]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string CPassword { get; set; }
    }


}

