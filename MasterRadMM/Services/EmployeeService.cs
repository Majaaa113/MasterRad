using MasterRadMM.Interfaces;
using MasterRadMM.ViewModels;
using MasterRadMM.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterRadMM.Models;

namespace MasterRadMM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MasterRadDbContext _context;

        public EmployeeService(MasterRadDbContext context)
        {
            _context = context;
        }

        public EmployeeViewModel Login(LoginViewModel login)
        {
            var fullName = login.Employee.Split(' ');
            var fname = fullName[0];
            var lname = fullName[1];

            var employee = _context.Employees.FirstOrDefault(x => x.Firstname.Equals(fname) && x.Lastname.Equals(lname) && x.Password.Equals(login.Password));

            if (employee != null)
            {
                return Utilities.CopyEntityFields<Employee, EmployeeViewModel>(employee);
            }

            return null;
        }

        public EmployeeViewModel Register(RegisterViewModel register)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Firstname.Equals(register.Firstname) && x.Lastname.Equals(register.Lastname) && x.Password.Equals(register.Password));

            if(employee != null)
            {
                return null;
            }

            employee = Utilities.CopyEntityFields<RegisterViewModel, Employee>(register);
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Utilities.CopyEntityFields<Employee, EmployeeViewModel>(employee);
        }
    }
}
