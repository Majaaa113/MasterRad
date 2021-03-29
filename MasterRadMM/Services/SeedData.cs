using MasterRadMM.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRadMM.Services
{
    public class SeedData
    {
        private readonly MasterRadDbContext _context;

        public SeedData(MasterRadDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Couriers.Any())
            {
                return;
            }

            _context.Couriers.Add(new Models.Courier { Firstname = "Marko", Lastname = "Markovic" });
            _context.Couriers.Add(new Models.Courier { Firstname = "Marija", Lastname = "Maric" });
            _context.Couriers.Add(new Models.Courier { Firstname = "Ana", Lastname = "Anic" });
            _context.Couriers.Add(new Models.Courier { Firstname = "Nikola", Lastname = "Nikolic" });
            _context.Couriers.Add(new Models.Courier { Firstname = "Stefan", Lastname = "Stefanovic" });
            _context.SaveChanges();

            _context.Customers.Add(new Models.Customer
            {
                Firstname = "Nikola",
                Lastname = "Nikolic",
                Available = 0,
                City = "Belgrade",
                Country = "Serbia",
                Street = "Street 1",
                PostalCode = 11000,
                IdentityCard = "0101991772020",
                AccountNo = "1000001"
            });

            _context.Customers.Add(new Models.Customer
            {
                Firstname = "Bojan",
                Lastname = "Bojanic",
                Available = 0,
                City = "Belgrade",
                Country = "Serbia",
                Street = "Street 2",
                PostalCode = 11000,
                IdentityCard = "0101991772021",
                AccountNo = "1000002"
            });

            _context.Customers.Add(new Models.Customer
            {
                Firstname = "Petar",
                Lastname = "Petrovic",
                Available = 0,
                City = "Belgrade",
                Country = "Serbia",
                Street = "Street 3",
                PostalCode = 11000,
                IdentityCard = "0101991772022",
                AccountNo = "1000003"
            });

            _context.Customers.Add(new Models.Customer
            {
                Firstname = "Slobodan",
                Lastname = "Slobodanovic",
                Available = 0,
                City = "Belgrade",
                Country = "Serbia",
                Street = "Street 4",
                PostalCode = 11000,
                IdentityCard = "0101991772024",
                AccountNo = "1000004"
            });

            _context.SaveChanges();
        }
    }
}
