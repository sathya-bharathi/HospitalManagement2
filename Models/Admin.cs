using System.ComponentModel.DataAnnotations;



namespace HospitalManagement.Models
{
    public partial class Admin
    {
        [EmailAddress]
        [Display(Name = "Email")]
        public string? EmailId { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        public string? Password { get; set; }
    }
}
