using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class TransactionDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sender")]
        public string Sender { get; set; }

        [Required]
        [Display(Name = "Reciever")]
        public string Reciever { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Created by")]
        public string Employee { get; set; }

        public string Status { get; set; }

        public string Courier { get; set; }

        public string SendingDate { get; set; }

        public string ComplitionDate { get; set; }
    }
}