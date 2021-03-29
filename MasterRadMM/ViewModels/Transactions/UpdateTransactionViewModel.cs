using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class UpdateTransactionViewModel
    {
        public int TransactionId { get; set; }
        public int CourierId { get; set; }

        [Display(Name = "Complition Date")]
        public string ComplitionDate { get; set; }

        [Display(Name = "Validation provided by courier")]
        public string Validation { get; set; }
    }
}