using MasterRadMM.ViewModels;
using System.Collections.Generic;

namespace MasterRadMM.Interfaces
{
    public interface ITransactionService
    {
        TransactionDetailsViewModel GetTransaction(int transactionId);
        List<TransactionListItemViewModel> ListTransactions();
        bool CreateTransaction(CreateTransactionViewModel createViewModel);
        bool BeginTransaction(BeginTransactionViewModel transactionView);
        bool UpdateTransaction(UpdateTransactionViewModel updateView);
        bool DeleteTransaction(int transactionId);
        int GetCourierIdForTransaction(int transactionId);
    }
}
