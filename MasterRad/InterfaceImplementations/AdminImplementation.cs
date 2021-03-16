using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MasterRad.Interfaces;
using MasterRad.ViewModels;

namespace MasterRad.Models
{
    public class AdminImplementation : IAdmin
    {
        private readonly IListOfEverything IList = new ListOfEverythingImplementation();
        private readonly string cs = ConnectionHelper.GetConnectionString();
        private string sql = null;         
        

        public List<UserViewModel> ListOfUsers()
        {
            List<UserInfo> userInfos = IList.GetUsers().ToList();
            List<UserViewModel> userViews = new List<UserViewModel>();

            foreach(var userInfo in userInfos)
            {
                UserViewModel userView = new UserViewModel();
                userView.Firstame = userInfo.Firstname;
                userView.Lastname = userInfo.Lastname;
                userView.Country = userInfo.Country;
                userView.City = userInfo.City;
                userView.Amount = userInfo.Available;
                userView.Address = userInfo.Address;
                userView.AccountNo = userInfo.AccountNo;
                foreach(var transaction in IList.GetTransactions().Where(x => x.Id == userInfo.Id).ToList())
                {
                    TransactionViewModel transactionView = new TransactionViewModel();
                    transactionView.Firstname = transaction.Firstname;
                    transactionView.Lastname = transaction.Lastname;

                    var emp = transactionView.Employee.Split();
                    string empFirstname = emp[0];
                    string empLastname = emp[1];

                    transactionView.Employee = IList.GetEmployees().Where(x => x.Id == transaction.EmployeeId).FirstOrDefault().Firstname + " " + IList.GetEmployees().Where(x => x.Id == transaction.EmployeeId).FirstOrDefault().Lastname;

                    transactionView.Amount = transaction.Amount;
                    transactionView.AccountNo = transaction.AccountNo;
                    transactionView.SendingDate = transaction.SendingDate.ToShortDateString();

                    userView.AllTransactions.Add(transactionView);
                }

                userViews.Add(userView);
            }
            return userViews;
        }

        public List<TransactionViewModel> ListOfTransactions()
        {
            List<TransactionViewModel> transactionViews = new List<TransactionViewModel>();
            List<Transaction> transactions = IList.GetTransactions().ToList();
            foreach(var transact in transactions)
            {
                TransactionViewModel transactionView = new TransactionViewModel();
                transactionView.Id = transact.Id;
                transactionView.AccountNo = transact.AccountNo;
                transactionView.Amount = transact.Amount;
                transactionView.Firstname = transact.Firstname;
                transactionView.Lastname = transact.Lastname;
                transactionView.SendingDate = transact.SendingDate.ToShortDateString();
                transactionView.Employee = IList.GetEmployees().Where(x => x.Id == transact.EmployeeId).FirstOrDefault().Firstname + " " + IList.GetEmployees().Where(x => x.Id == transact.EmployeeId).FirstOrDefault().Firstname;
                if (transact.StatusT == "1" || transact.StatusT=="Waiting")
                {
                    transactionView.Status = Transaction.Status.Waiting.ToString();
                }
                if (transact.StatusT == "2" || transact.StatusT == "InProgress")
                {
                    transactionView.Status = Transaction.Status.InProgress.ToString();
                }
                if (transact.StatusT == "3" || transact.StatusT == "Delivered")
                {
                    transactionView.Status = Transaction.Status.Delivered.ToString();
                }
                if (transact.ComplitionDate != null) transactionView.ComplitionDate = transact.ComplitionDate.ToShortDateString();
                if (transact.CourierId != 0) transactionView.Courier = IList.GetCouriers().Where(x => x.Id == transact.CourierId).FirstOrDefault().Firstname + " " + IList.GetCouriers().Where(x => x.Id == transact.CourierId).FirstOrDefault().Lastname;

                transactionViews.Add(transactionView);
            }

            return transactionViews;
        }

        public UserViewModel GetUser(string AccountNo)
        {
            return ListOfUsers().Where(x => x.AccountNo == AccountNo).FirstOrDefault();
        }

        public EmployeeViewModel GetEmployee(LoginViewModel loginView)
        {
            List<TransactionViewModel> tViews = new List<TransactionViewModel>();
            EmployeeViewModel emp = new EmployeeViewModel();
            var emplo = loginView.Employee.Split();
            string empFirstname = emplo[0];
            string empLastname = emplo[1];


            Employee employee = new Employee();
            try
            {
                employee = IList.GetEmployees().Where(x => x.Firstname.ToLower() == empFirstname.ToLower() && x.Lastname.ToLower() == empLastname.ToLower() && x.Password == loginView.Password).FirstOrDefault();
                emp.Firstname = employee.Firstname;
                emp.Lastname = employee.Lastname;
                if(IList.GetTransactions().Where(x=>x.EmployeeId == employee.Id).ToList()!=null)
                {
                    foreach(var transact in IList.GetTransactions().Where(x => x.EmployeeId == employee.Id).ToList())
                    {
                        TransactionViewModel transactionView = new TransactionViewModel();
                        transactionView.AccountNo = transact.AccountNo;
                        transactionView.Amount = transact.Amount;
                        transactionView.Firstname = transact.Firstname;
                        transactionView.Lastname = transact.Lastname;
                        transactionView.SendingDate = transact.SendingDate.ToShortDateString();
                        if (transact.ComplitionDate != null) transactionView.ComplitionDate = transact.ComplitionDate.ToShortDateString();
                        else
                        {
                            transactionView.ComplitionDate = "Not complited";
                        }
                        if (transact.CourierId != 0) transactionView.Courier = IList.GetCouriers().Where(x => x.Id == transact.CourierId).FirstOrDefault().Firstname + " " + IList.GetCouriers().Where(x => x.Id == transact.CourierId).FirstOrDefault().Lastname;

                        tViews.Add(transactionView); 
                    }
                }
                emp.AllTransactionsByThisEmployee = tViews;
                return emp;
            }catch(Exception e)
            {
                string error = e.ToString();
                return null;
            }
        }
    }
}