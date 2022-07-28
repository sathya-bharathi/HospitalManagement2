using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public partial class PatientRegistration
    {
        [EmailAddress]
        [Required]

        public string EmailId { get; set; } = null!;

        [Required]
        [Display(Name = "Patient Name")]
        public string? PatientName { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Enter a valid age")]
        public int? Age { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$",
      ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet," +
      " 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string? Password { get; set; }


        [NotMapped]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                  ErrorMessage = "Entered phone format is not valid.")]
        public string? PhoneNumber { get; set; }
    }
}
