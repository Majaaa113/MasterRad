using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterRadMM.Interfaces;
using MasterRadMM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterRadMM.Filters;

namespace MasterRadMM.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICustomerService _customerService;
        private readonly ICourierService _courierService;

        public TransactionsController(ITransactionService transactionService, ICustomerService customerService, ICourierService courierService)
        {
            _transactionService = transactionService;
            _customerService = customerService;
            _courierService = courierService;
        }

        [HttpGet]
        [ServiceFilter(typeof(AllowOnlyEmployee))]
        public IActionResult Index()
        {
            return View(_transactionService.ListTransactions());
        }

        [HttpGet]
        [ServiceFilter(typeof(AllowOnlyEmployee))]
        public IActionResult Create()
        {
            var customers = _customerService.ListCustomerInfos();
            ViewBag.AvailableCustomers = new SelectList(customers, "Id", "CustomerInfo");
            return View(new CreateTransactionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTransactionViewModel transaction)
        {
            var success = _transactionService.CreateTransaction(transaction);

            return RedirectToIndex(success);
        }

        [HttpGet]
        [ServiceFilter(typeof(AllowOnlyEmployee))]
        public IActionResult Begin(int id)
        {
            var beginTransaction = new BeginTransactionViewModel { TransactionId = id };
            var courieres = _courierService.ListCouriers();
            ViewBag.AvailableCouriers = new SelectList(courieres, "Id", "FullName");
            return View(beginTransaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Begin(BeginTransactionViewModel beginTransaction)
        {
            var success = _transactionService.BeginTransaction(beginTransaction);

            return RedirectToIndex(success);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var courierId = _transactionService.GetCourierIdForTransaction(id);
            var updateTransaction = new UpdateTransactionViewModel { TransactionId = id, CourierId = courierId };

            return View(updateTransaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdateTransactionViewModel updateTransaction)
        {
            var success = _transactionService.UpdateTransaction(updateTransaction);

            return RedirectToIndex(success);
        }

        [HttpGet]
        [ServiceFilter(typeof(AllowOnlyEmployee))]
        public IActionResult Delete(int id)
        {
            var success = _transactionService.DeleteTransaction(id);

            return RedirectToIndex(success);
        }

        private IActionResult RedirectToIndex(bool success)
        {
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
