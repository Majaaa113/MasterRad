using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MasterRad.Interfaces;

namespace MasterRad.Models
{
    public class ListOfEverythingImplementation : IListOfEverything
    {
        private readonly string cs = ConnectionHelper.GetConnectionString();
        private string sql = null;

        public IEnumerable<Courier> GetCouriers()
        {
            List<Courier> couriers = new List<Courier>();
            sql = "select * from courier";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Courier courier = new Courier();
                    courier.Firstname = reader.GetString(0);
                    courier.Lastname = reader.GetString(1);
                    if (!reader.IsDBNull(2)) courier.Validation = reader.GetString(2);
                    if (!reader.IsDBNull(3)) courier.ComplitionDate = Convert.ToDateTime(reader.GetString(3));
                    courier.Id = Convert.ToInt32(reader.GetValue(4));

                    couriers.Add(courier);
                }
            }

            return couriers;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            sql = "select * from Employee";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                DataSet set = new DataSet();
                adapter.Fill(set, "Employee");

                return from DataRow in set.Tables["Employee"].AsEnumerable()
                       select new Employee
                       {
                           Id = Convert.ToInt32(DataRow["Id"]),
                           Firstname = DataRow["Firstname"].ToString(),
                           Lastname = DataRow["Lastname"].ToString(),
                           Password = DataRow["Password"].ToString()
                       };

            }
        }
        public IEnumerable<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            sql = "select * from banktransactions";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.Firstname = reader.GetString(0);
                    transaction.Lastname = reader.GetString(1);
                    transaction.AccountNo = reader.GetString(2);
                    transaction.Amount = Convert.ToDouble(reader.GetString(3));
                    transaction.SendingDate = reader.GetDateTime(4);
                    if (!reader.IsDBNull(5)) transaction.ComplitionDate = reader.GetDateTime(5);
                    transaction.EmployeeId = Convert.ToInt32(reader.GetValue(6));
                    transaction.UserId = Convert.ToInt32(reader.GetValue(7));
                    if (!reader.IsDBNull(8)) transaction.CourierId = Convert.ToInt32(reader.GetValue(8));
                    transaction.StatusT = reader.GetString(9);
                    transaction.Id = Convert.ToInt32(reader.GetValue(10));

                    transactions.Add(transaction);

                }

                return transactions;
            }
        }
        public IEnumerable<UserInfo> GetUsers()
        {
            sql = "select * from UserInfo";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet set = new DataSet();
                adapter.Fill(set, "UserInfo");

                return from DataRow in set.Tables["UserInfo"].AsEnumerable()
                       select new UserInfo
                       {
                           Id = Convert.ToInt32(DataRow["Id"]),
                           Firstname = DataRow["Firstname"].ToString(),
                           Lastname = DataRow["Lastname"].ToString(),
                           PostalCode = Convert.ToInt32(DataRow["PostalCode"]),
                           City = DataRow["City"].ToString(),
                           Country = DataRow["Country"].ToString(),
                           Available = Convert.ToDouble(DataRow["Available"]),
                           Address = DataRow["Address"].ToString(),
                           AccountNo = DataRow["AccountNo"].ToString()
                       };
            }
        }
    }
}