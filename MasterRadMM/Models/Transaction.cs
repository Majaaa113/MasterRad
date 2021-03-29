using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MasterRadMM.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required] public int SenderId { get; set; }
        [Required] public int RecieverId { get; set; }
        [Required] public double Amount { get; set; }
        [Required] public DateTime SendingDate { get; set; }        
        public int EmployeeId { get; set; }
        public int? CourierId { get; set; }
        public string Validation { get; set; }
        public TransactionStatus Status { get; set; }

        public virtual Customer Sender { get; set; }
        public virtual Customer Reciever { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Courier Courier { get; set; }
    }
}
