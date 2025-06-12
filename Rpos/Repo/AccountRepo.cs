using Bank_mangement_system.DTOs;
using Bank_mangement_system.Models;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Bank_mangement_system.Rpos.Repo
{
    public class AccountRepo:IAccountRepo
    {
        private readonly AppDbContext _context;
        public AccountRepo(AppDbContext contxt) 
        { 
            _context = contxt;
        }

        public void AddAccountExixtcustomer(AccountuserDto accountuser)
        {
           var customer=_context.Accounts.Include(x=>x.Customer).FirstOrDefault(x=>x.CustomerId==accountuser.CustomerId);
            if (customer == null)
            {
                throw new Exception($"The customer of id number {accountuser.CustomerId} not found");
            }
            var account = new Account
            {
                CustomerId = customer.CustomerId,
                AccountNumber = accountuser.AccountNumber,
                Balance = accountuser.Balance,
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
          
        }
    }
}
