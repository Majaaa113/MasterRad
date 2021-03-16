using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterRad.Models;

namespace MasterRad.Interfaces
{
    public interface IListOfEverything
    {
        IEnumerable<UserInfo> GetUsers();
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Courier> GetCouriers();
    }
}
