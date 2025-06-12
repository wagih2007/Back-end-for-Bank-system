using Bank_mangement_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_mangement_system
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(a=>a.AccountNumber).IsUnique();
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Branch> Branches { get; set; } 
    }
}
