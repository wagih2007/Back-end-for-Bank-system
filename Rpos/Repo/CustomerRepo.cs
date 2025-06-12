using Bank_mangement_system.DTOs;
using Bank_mangement_system.Models;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Bank_mangement_system.Rpos.Repo
{
    public class CustomerRepo:ICustomerRepo
    {
        private readonly AppDbContext _dbcontext;
        public CustomerRepo(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void AddCustomerreated(Customerdto customerdto)
        {
            var custom = new Customer
            {
                Name = customerdto.Name,
                PhoneNumber=customerdto.PhoneNumber,
                EmailAddress=customerdto.EmailAddress,
                branches=customerdto.BranchDtos.Select(
                    x=>new Branch
                    {
                        Name=x.Name,
                        Location=x.Location,
                    }).ToList(),
                Accounts=customerdto.AccountDtos.Select(
                    x=>new Account
                    {
                        Balance=x.Balance,
                        AccountNumber=x.AccountNumber,
                    }).ToList(),
                bankCard=new BankCard
                {
                    CardNumber=customerdto.bankCarddto.CardNumber,
                    ExpiryDate=customerdto.bankCarddto.ExpiryDate.Value,
                }
            };
            _dbcontext.Customers.Add(custom);   
            _dbcontext.SaveChanges();
        }

        public Customerdto getCustomerbyId(int id)
        {
           var customer= _dbcontext.Customers.Include(x=>x.bankCard)
                                    .Include(x=>x.branches)
                                    .FirstOrDefault(x=>x.Id==id);
            if(customer==null)
            {
                throw new Exception($"The customer  id:  {id} is  not found.");
            }
            var restult = new Customerdto
            {
                Name = customer.Name,
                EmailAddress= customer.EmailAddress,
                PhoneNumber= customer.PhoneNumber,
                BranchDtos=customer.branches.Select(
                    x=>new BranchDto
                    {
                        Name=x.Name,
                        Location=x.Location
                    }).ToList(),
                bankCarddto=new BankCardDto
                {
                    CardNumber=customer.bankCard.CardNumber,
                    ExpiryDate= customer.bankCard.ExpiryDate.Value,
                }
            };

            return restult;

        }
    }
}
