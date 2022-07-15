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
        [DataType(DataType.Text)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Reg.No")]
        public int Reg_no { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        public long Mobile_No { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }

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

        public virtual ICollection<MarksTable> markstable { get; set; }
        
    }
}
