using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterRadMM.ViewModels
{
    public class CustomerInfoViewModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNo { get; set; }

        [Display(Name = "Available")]
        public decimal Available { get; set; }

        [Display(Name = "Identity Card")]
        public string IdentityCard { get; set; }

    }
}