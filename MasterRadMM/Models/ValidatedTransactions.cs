using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterRadMM.Models
{
    public class ValidatedTransactions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public int TransactionId { get; set; }
        [Required] public int CourierId { get; set; }
        [Required] public string Validation { get; set; }
        [Required] public DateTime ComplitionDate { get; set; }

    }
}
