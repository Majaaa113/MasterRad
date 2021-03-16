using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterRad.ViewModels
{
    public class EmployeeViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<TransactionViewModel> AllTransactionsByThisEmployee { get; set; }
    }
}