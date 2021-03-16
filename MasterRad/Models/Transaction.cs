using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterRad.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccountNo { get; set; }
        public double Amount { get; set; }
        public DateTime SendingDate { get; set; }
        public DateTime ComplitionDate { get; set; }
        public int EmployeeId { get; set; }
        public int CourierId { get; set; }
        public int UserId { get; set; }
        public string StatusT { get; set; }
        public static Status TransactionStatus { get; set; }


        public enum Status
        {
            Waiting,
            InProgress,
            Delivered
        }

    }
}