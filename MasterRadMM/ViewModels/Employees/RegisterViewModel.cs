using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "Employee")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Employee")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must have atleast 8 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(8, ErrorMessage = "Password must have atleast 8 characters")]
        public string ConfirmPassword { get; set; }
    }
}