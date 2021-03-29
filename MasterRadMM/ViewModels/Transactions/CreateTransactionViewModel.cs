using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class CreateTransactionViewModel
    {
        [Display(Name = "Sender")]
        public int SenderId { get; set; }
        public CreateCustomerViewModel Sender { get; set; }

        [Display(Name = "Reciever")]
        public int RecieverId { get; set; }
        public CreateCustomerViewModel Reciever { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}