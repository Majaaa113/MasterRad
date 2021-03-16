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
    public class CrudImplementationADO : ICrudOperations
    {
        private readonly IListOfEverything IList = new ListOfEverythingImplementation();
        private readonly string cs = ConnectionHelper.GetConnectionString();
        private string sql = null;


        public string BeginTransaction(TransactionViewModel viewModel)
        {
            sql = "INSERT INTO BankTransactions (firstname,lastname,accountno,amount,sendingdate,employeeid,userid,status) values(@firstname,@lastname,@accountno,@amount,@sendingdate,@employeeid,@transactionstatus,@userid)";

            int userId;
            var emp = viewModel.Employee.Split();
            string empFirstname = emp[0];
            string empLastname = emp[1];

            int empId = IList.GetEmployees().Where(x => x.Firstname == empFirstname && x.Lastname == empLastname).FirstOrDefault().Id;
            try
            {
                userId = IList.GetUsers().Where(x => x.AccountNo == viewModel.AccountNo).FirstOrDefault().Id;
            }
            catch(Exception e)
            {
                string error = e.ToString();
                return "Not a valid account number";
            }
            

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstname", viewModel.Firstname);
                cmd.Parameters.AddWithValue("@lastname", viewModel.Lastname);
                cmd.Parameters.AddWithValue("@accountno", viewModel.AccountNo);
                cmd.Parameters.AddWithValue("@amount", viewModel.Amount);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.Parameters.AddWithValue("@sendingdate", viewModel.SendingDate);
                cmd.Parameters.AddWithValue("@employeeid", empId);
                cmd.Parameters.AddWithValue("@transactionstatus", Transaction.Status.Waiting);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return "Transaction started";
                }
                catch(Exception e)
                {
                    string error = e.ToString();
                    return "There is a problem with the transaction.Transaction aborted";
                }
            }
        }

        public string UpdateTransaction(UpdateTransactionViewModel viewModel)
        {
            var cor = viewModel.Courier.Split();            
            string corFirstname = cor[0];
            string corLastname = cor[1];

            if(IList.GetCouriers().Where(x => x.Firstname == corFirstname && x.Lastname == corLastname).FirstOrDefault() == null)
            {
                sql = "insert into courier (firstname , lastname) values (@firstname,@lastname)";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand(sql,con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@firstname", corFirstname);
                    cmd.Parameters.AddWithValue("@lastname", corLastname);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        string error = e.ToString();
                        return "Something went wrong with courier firstname and lastname , please try again";
                    }
                }
            }

            int courierId = IList.GetCouriers().Where(x => x.Firstname == corFirstname && x.Lastname == corLastname).FirstOrDefault().Id;


            if(viewModel.Validation!=null)
            {
                sql = "update banktransactions set courierId = @courierId, status = @status, complitiondate = @complitiondate where id = @id";
            }
            else
            {
                sql = "update banktransactions set courierId = @courierId, status = @status where id = @id";
            }
            

            using (SqlConnection con = new SqlConnection(cs))
            {
                string status = null;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@courierId", courierId);
                cmd.Parameters.AddWithValue("@id", viewModel.TransactionId);
                if(viewModel.Validation == null)
                {                    
                    status = Transaction.Status.InProgress.ToString();
                }
                else
                {
                    cmd.Parameters.AddWithValue("@complitiondate", DateTime.Now.ToShortDateString());
                    status = Transaction.Status.Delivered.ToString();
                    cmd.Parameters.AddWithValue("@status", status);
                    con.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return "Transaction updated";
                    }
                    catch (Exception e)
                    {
                        string error = e.ToString();
                        con.Close();
                        return "Transaction could not be updated";
                    }
                    
                }
                cmd.Parameters.AddWithValue("@status", status);
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    return "Transaction Updated";
                }
                catch(Exception e)
                {
                    string error = e.ToString();
                    return "Transaction could not be updated";
                }
            }
        }

        public string DeleteTransaction(int id)
        {
            sql = "delete from banktransactions where id = @id";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return "Transaction deleted";
                }
                catch(Exception e)
                {
                    string error = e.ToString();
                    return "Transaction could not be deleted";
                }
            }
        }
    }
}