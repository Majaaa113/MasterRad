using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Make sure that you log in using this format (Firstname Lastname)")]
        [Display(Name = "Employee")]
        public string Employee { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must have atleast 8 characters")]
        public string Password { get; set; }
    }
}