using MasterRadMM.Interfaces;
using MasterRadMM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRadMM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public AccountController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel login)
        {
            var employee = _employeeService.Login(login);
            
            return RedirectToTransactions(employee, false);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel register)
        {
            var employee = _employeeService.Register(register);

            return RedirectToTransactions(employee, true);
        }

        private IActionResult RedirectToTransactions(EmployeeViewModel employee, bool register)
        {
            if(employee != null)
            {
                HttpContext.Session.SetString("Username", $"{employee.Lastname} {employee.Firstname}");
                HttpContext.Session.SetInt32("EmployeeId", employee.Id);

                return RedirectToAction("Index", "Transactions");
            }
            else
            {
                if(register)
                {
                    ViewBag.Error = "Employee already exists";
                }
                return View();
            }            
        }
    }
}
