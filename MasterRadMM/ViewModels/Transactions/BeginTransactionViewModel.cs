using System.ComponentModel.DataAnnotations;

namespace MasterRadMM.ViewModels
{
    public class BeginTransactionViewModel
    {
        public int TransactionId { get; set; }

        public CreateCourierViewModel Courier { get; set; }

        [Required]
        [Display(Name = "Courier")]
        public int CourierId { get; set; }
    }
}