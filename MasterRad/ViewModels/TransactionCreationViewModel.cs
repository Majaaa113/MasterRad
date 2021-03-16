using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterRad.ViewModels
{
    public class TransactionCreationViewModel
    {
        [Required]
        [Display(Name = "Sender Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Sender Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Send to account number")]
        public string AccountNo { get; set; }

        [Required]
        public double Amount { get; set; }

    }
}