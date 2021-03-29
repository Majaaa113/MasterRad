using MasterRadMM.Interfaces;
using MasterRadMM.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterRadMM.ViewModels;
using MasterRadMM.Models;

namespace MasterRadMM.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MasterRadDbContext _context;

        public CustomerService(MasterRadDbContext context)
        {
            _context = context;
        }

        public int CreateCustomer(CreateCustomerViewModel customerViewModel)
        {
            var customer = Utilities.CopyEntityFields<CreateCustomerViewModel, Customer>(customerViewModel);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer.Id;
        }

        public CustomerInfoViewModel GetCustomerInfo(string accountNo)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.AccountNo.Equals(accountNo));

            if(customer != null)
            {
                return Utilities.CopyEntityFields<Customer, CustomerInfoViewModel>(customer);
            }

            return null;
        }

        public List<CustomerListItemViewModel> ListCustomerInfos()
        {
            return _context.Customers.Select(x => new CustomerListItemViewModel 
            { 
                Id = x.Id ,
                CustomerInfo = $"{x.Firstname} {x.Lastname}, Identification Card : {x.IdentityCard}, Account Number {x.AccountNo}"  
            })
                .ToList();
        }
    }
}
