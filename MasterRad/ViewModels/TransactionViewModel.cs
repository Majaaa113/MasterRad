using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterRad.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Sender Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Sender Lastname")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name ="Send to account number")]
        public string AccountNo { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [Display(Name ="Created by")]
        public string Employee { get; set; }

        public string Status { get; set; }

        public string Courier { get; set; }

        public string SendingDate { get; set; }

        public string ComplitionDate { get; set; }
    }
}