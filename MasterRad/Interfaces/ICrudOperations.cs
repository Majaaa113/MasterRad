using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterRad.ViewModels;

namespace MasterRad.Interfaces
{
    public interface ICrudOperations
    {
        string BeginTransaction(TransactionViewModel transactionView);
        string UpdateTransaction(UpdateTransactionViewModel updateView);
        string DeleteTransaction(int id);
    }
}
