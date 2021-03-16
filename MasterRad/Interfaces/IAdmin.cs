using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterRad.ViewModels;

namespace MasterRad.Interfaces
{
    public interface IAdmin 
    {
        UserViewModel GetUser(string AccountNo);
        List<UserViewModel> ListOfUsers();
        EmployeeViewModel GetEmployee(LoginViewModel loginView);
        List<TransactionViewModel> ListOfTransactions();
    }
}
