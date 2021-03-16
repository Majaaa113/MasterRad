using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterRad.Interfaces;
using MasterRad.Models;
using MasterRad.ViewModels;

namespace MasterRad.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAdmin admin = new AdminImplementation();
        private readonly ICrudOperations crud = new CrudImplementationADO();

        public ActionResult LogIn()
        {
            if (TempData["InvalidUser"] != null) ViewBag.Invalid = TempData["InvalidUser"].ToString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginViewModel loginView)
        {
            if(ModelState.IsValid)
            {
                if (admin.GetEmployee(loginView) != null)
                {
                    EmployeeViewModel emp = admin.GetEmployee(loginView);
                    Session["Firstname"] = emp.Firstname;
                    Session["Lastname"] = emp.Lastname;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["InvalidUser"] = "User is invalid";
                    return RedirectToAction("LogIn");
                }
            }
            return View("LogIn");
        }

        public ActionResult NewTransaction()
        {
            if (TempData["Feedback"] != null) ViewBag.Feedback = TempData["Feedback"].ToString();
            return View();
        }

        public ActionResult ListOfTransactions()
        {
            if (TempData["Deleted"] != null) ViewBag.Deleted = TempData["Deleted"].ToString();
            return View(admin.ListOfTransactions());
        }

        public ActionResult UpdateTransaction(int id)
        {
            if (id == 0) return RedirectToAction("Index", "Home");
            UpdateTransactionViewModel upModel = new UpdateTransactionViewModel();
            if (TempData["FeedbackUpdate"] != null) ViewBag.Update = TempData["FeedbackUpdate"].ToString();
            upModel.TransactionId = id;
            return View(upModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTransaction(UpdateTransactionViewModel updateTransactionView)
        {
            if(ModelState.IsValid)
            {
                TempData["FeedbackUpdate"] = crud.UpdateTransaction(updateTransactionView);
                return RedirectToAction("ListOfTransactions");
            }

            return View("UpdateTransaction", new { id = updateTransactionView.TransactionId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTransaction(TransactionCreationViewModel transactionView)
        {
            TransactionViewModel viewModel = new TransactionViewModel();
            viewModel.Firstname = transactionView.Firstname;
            viewModel.Lastname = transactionView.Lastname;
            viewModel.AccountNo = transactionView.AccountNo;
            viewModel.Amount = transactionView.Amount;
            viewModel.Employee = Session["Firstname"].ToString() + " " + Session["Lastname"].ToString();
            viewModel.SendingDate = DateTime.Now.ToShortDateString();

            if (ModelState.IsValid)
            {
                TempData["Transaction"] = crud.BeginTransaction(viewModel);
                return RedirectToAction("ListOfTransactions");
            }

            return View("NewTransaction");
        }

        public ActionResult DeleteTransaction(int id)
        {
            TempData["Deleted"] = crud.DeleteTransaction(id);
            return RedirectToAction("ListOfTransactions");
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}