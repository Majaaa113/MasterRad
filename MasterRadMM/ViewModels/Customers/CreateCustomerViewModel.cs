using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "PostalCode")]
        public int PostalCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        public string AccountNo { get; set; }

        [Required]
        public string IdentityCard { get; set; }
    }


}