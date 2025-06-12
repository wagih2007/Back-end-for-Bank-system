using Bank_mangement_system.DTOs;
using Bank_mangement_system.Models;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.EntityFrameworkCore;

namespace Bank_mangement_system.Rpos.Repo
{
    public class BranchRepo:IBranchRepo
    {
        private readonly AppDbContext _context;
        public BranchRepo(AppDbContext context) 
        {
            _context = context; 
        }

        public void AddBranchCustomers(BranchCustomerDto branchCustomerDto)
        {
            if (_context.Branches.Any(b => b.Name.ToLower() == branchCustomerDto.Name.ToLower()))
                throw new Exception("This branch already exists.");

            var branch = new Branch
            {
                Location = branchCustomerDto.Location,
                Name = branchCustomerDto.Name,
                Customers = new List<Customer>()
            };

            if (branchCustomerDto.CustomersId != null && branchCustomerDto.CustomersId.Any())
           
            {
                var users = _context.Customers
                     .Where(x => branchCustomerDto.CustomersId.Contains(x.Id)).ToList();
               

                foreach (var user in users) 
                {
                    branch.Customers.Add(user);
                }

            }
            _context.Branches.Add(branch);
            _context.SaveChanges();
        }

        public List<GetBranchCustomerssDto> GetAllBranches()
        {
            var Branches = _context.Branches.Include(x => x.Customers)
                    .ThenInclude(x => x.Accounts)
                    .Select(x => new GetBranchCustomerssDto
                    {
                        Name = x.Name,
                        Location = x.Location,
                        GetCustomerdtos = x.Customers.Select(
                            z => new Customto
                            {
                                Name= z.Name,
                                AccountDtos=z.Accounts.Select(
                                    w=>new AccountDto
                                    {
                                        AccountNumber=w.AccountNumber,
                                        Balance=w.Balance,
                                    }).ToList(),
                                EmailAddress=z.EmailAddress,
                                PhoneNumber=z.PhoneNumber,
                                
                            }).ToList()

                    }).ToList();
            if (Branches == null)
            {
                throw new Exception("There is no data");
            }
            return Branches;
        }

        public void Updata(int id, BranchCustomerDto branchCustomerDto)
        {
            var branch=_context.Branches.Include(x => x.Customers)
                    .FirstOrDefault(x=>x.Id==id);
            if (branch == null)
                throw new Exception("There is no  id  ");

            branch.Name=branchCustomerDto.Name;
            branch.Location=branchCustomerDto.Location;
            
            if(branchCustomerDto.CustomersId!=null && branchCustomerDto.CustomersId.Any())
            {
                var customer=_context.Customers.Where(x=>branchCustomerDto.CustomersId.Contains(x.Id)).ToList();

                branch.Customers.Clear();

                foreach(var x in customer)
                {
                    branch.Customers.Add(x);
                }
            }

            _context.Branches.Update(branch);
            _context.SaveChanges();
        }
        public void DeleteBrach(int id)
        {
            var brach = _context.Branches.Find(id);
            if(brach == null)
            {
                throw new Exception("The function  is not found");
            }
            _context.Branches.Remove(brach);
            _context.SaveChanges();
        }
    }
}