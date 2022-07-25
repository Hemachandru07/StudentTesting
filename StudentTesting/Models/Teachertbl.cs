using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Models
{
    public class Teachertbl
    {
        
        [Key]
        [Display(Name = "Faculty Id")]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Numbers and special characters are not allowed")]
        [Display(Name = "Faculty Name")]
        public string FacultyName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Department { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password does Not Match")]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string CPassword { get; set; }
    }


}

