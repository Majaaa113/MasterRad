using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterRad.ViewModels
{
    public class UserViewModel
    {
        public string Firstame { get; set; }

        public string Lastname { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        [Display(Name ="Account Number")]
        public string AccountNo { get; set; }

        [Display(Name ="Available")]
        public double Amount { get; set; }

        [Display(Name ="All transactions")]
        public List<TransactionViewModel> AllTransactions { get; set; }
    }
}