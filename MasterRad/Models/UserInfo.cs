using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterRad.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string AccountNo { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public double Available { get; set; }
        //public List<Transaction> AllTransactions { get; set; }
    }
}