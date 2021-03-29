using MasterRadMM.Interfaces;
using MasterRadMM.EntityFramework;
using MasterRadMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterRadMM.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MasterRadMM.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly MasterRadDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public TransactionService(MasterRadDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public bool CreateTransaction(CreateTransactionViewModel createViewModel)
        {
            var transaction = Utilities.CopyEntityFields<CreateTransactionViewModel, Transaction>(createViewModel);
            transaction.EmployeeId = _httpContext.HttpContext.Session.GetInt32("EmployeeId").Value;
            _context.Transactions.Add(transaction);
            return _context.SaveChanges() > 0;
        }

        public bool BeginTransaction(BeginTransactionViewModel transactionView)
        {
            var transaction = _context.Transactions.Find(transactionView.TransactionId);
            transaction.CourierId = transactionView.CourierId;
            transaction.Status = TransactionStatus.InProgress;
            _context.Transactions.Update(transaction);
            return _context.SaveChanges() > 0;
        }       

        public bool DeleteTransaction(int transactionId)
        {
            _context.Transactions.Remove(_context.Transactions.Find(transactionId));
            return _context.SaveChanges() > 0;
        }

        public int GetCourierIdForTransaction(int transactionId)
        {
            return _context.Transactions.Find(transactionId).CourierId.Value;
        }

        public TransactionDetailsViewModel GetTransaction(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            var transViewModel = Utilities.CopyEntityFields<Transaction, TransactionDetailsViewModel>(transaction);

            var sender = _context.Customers.Find(transaction.SenderId);
            var reciever = _context.Customers.Find(transaction.RecieverId);

            transViewModel.Sender = $"{sender.Firstname} {sender.Lastname}";
            transViewModel.Reciever = $"{reciever.Firstname} {reciever.Lastname}";
            transViewModel.Status = Enum.GetName(typeof(TransactionStatus), transaction.Status);

            var validated = _context.ValidatedTransactions.FirstOrDefault(x => x.TransactionId == transaction.Id);

            if (validated != null)
            {
                transViewModel.ComplitionDate = validated.ComplitionDate.ToString();
                transViewModel.Status = Enum.GetName(typeof(TransactionStatus), TransactionStatus.Delivered);
            }

            return transViewModel;

        }

        private TransactionListItemViewModel CreateTransactionListItem(Transaction transaction)
        {
            var transViewModel = new TransactionListItemViewModel
            {
                Id = transaction.Id,
                SendingDate = transaction.SendingDate.ToString(),
                Status = Enum.GetName(typeof(TransactionStatus), transaction.Status)
            };

            var sender = _context.Customers.Find(transaction.SenderId);
            var reciever = _context.Customers.Find(transaction.RecieverId);

            transViewModel.Sender = $"{sender.Firstname} {sender.Lastname}";
            transViewModel.Reciever = $"{reciever.Firstname} {reciever.Lastname}";

            return transViewModel;
        }

        public List<TransactionListItemViewModel> ListTransactions()
        {
            var list = new List<TransactionListItemViewModel>();
            var transactions = _context.Transactions.ToList();
            transactions.ForEach(x =>
            {
                list.Add(CreateTransactionListItem(x));
            });

            return list;
        }

        public bool UpdateTransaction(UpdateTransactionViewModel updateView)
        {
            var vTransaction = Utilities.CopyEntityFields<UpdateTransactionViewModel, ValidatedTransactions>(updateView);
            _context.ValidatedTransactions.Add(vTransaction);

            var transaction = _context.Transactions.Find(updateView.TransactionId);
            transaction.Status = TransactionStatus.Delivered;
            _context.Transactions.Update(transaction);           

            return _context.SaveChanges() > 0;
        }
    }
}
