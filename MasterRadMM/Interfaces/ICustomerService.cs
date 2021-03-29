using MasterRadMM.ViewModels;
using System.Collections.Generic;

namespace MasterRadMM.Interfaces
{
    public interface ICustomerService
    {
        int CreateCustomer(CreateCustomerViewModel customer);
        CustomerInfoViewModel GetCustomerInfo(string AccountNo);
        List<CustomerListItemViewModel> ListCustomerInfos();
    }
}
