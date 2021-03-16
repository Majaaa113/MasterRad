using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MasterRad.Models;

namespace MasterRad.ViewModels
{
    public class UpdateTransactionViewModel
    {
        public int TransactionId { get; set; }

        [Required(ErrorMessage ="You must atleast update courier")]
        [Display(Name = "Courier full name (Firstname Lastname)")]
        public string Courier { get; set; }

        [Display(Name ="Complition Date")]
        public string ComplitionDate { get; set; }
        
        [Display(Name = "Validation provided by courier")]
        public string Validation { get; set; }
    }
}