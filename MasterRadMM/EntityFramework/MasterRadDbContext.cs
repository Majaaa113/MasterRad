using MasterRadMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterRadMM.EntityFramework
{
    public class MasterRadDbContext : DbContext
    {
        public MasterRadDbContext(DbContextOptions<MasterRadDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ValidatedTransactions> ValidatedTransactions { get; set; }
    }
}
