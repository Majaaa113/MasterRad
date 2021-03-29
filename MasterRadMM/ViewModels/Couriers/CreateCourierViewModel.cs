using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class CreateCourierViewModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "Employee")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Employee")]
        public string LastName { get; set; }
    }
}