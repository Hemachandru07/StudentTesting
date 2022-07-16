using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTesting.Models
{
    public class Studenttbl
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Numbers and special characters are not allowed")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Reg.No")]
        [MaxLength(7)]
        public string Reg_no { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(13, MinimumLength = 10)]
        public string Mobile_No { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }

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

        public virtual ICollection<Marks> marks { get; set; }

        
        
    }
}
