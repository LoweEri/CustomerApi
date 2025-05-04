
using Microsoft.EntityFrameworkCore;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Lowe", LastName = "Eriksson", PhoneNumber = "1234567890" },
                new Customer { CustomerId = 2, FirstName = "Ewelina", LastName = "Wojtkoviak", PhoneNumber = "0987654321" }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, CustomerId = 1, Status = "Active", Balance = 1000.00m, CreationTimestamp = DateTime.UtcNow, UpdatedTimestamp = DateTime.UtcNow },
                new Account { AccountId = 2, CustomerId = 2, Status = "Active", Balance = 500.00m, CreationTimestamp = DateTime.UtcNow, UpdatedTimestamp = DateTime.UtcNow }
            );
        }
    }
}
