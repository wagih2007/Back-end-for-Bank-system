using Bank_mangement_system.DTOs;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_mangement_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _customerRepo;
        public AccountController(IAccountRepo customerrepo)
        {
            _customerRepo = customerrepo;
        }

        [HttpPost]
        public IActionResult AddAccountforExistinguser(AccountuserDto customerdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _customerRepo.AddAccountExixtcustomer(customerdto);
                return Ok("Successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
