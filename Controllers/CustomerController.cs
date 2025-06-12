using Bank_mangement_system.DTOs;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_mangement_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerController(ICustomerRepo customerrepo)
        {
            _customerRepo = customerrepo;
        }

        [HttpPost]
        public IActionResult Addcustomer(Customerdto customerdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _customerRepo.AddCustomerreated(customerdto);
                return Ok("Successful.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult Getcustomer(int id)
        {
            var customer=_customerRepo.getCustomerbyId(id);
            try
            {
                if (customer == null)
                {
                    throw new Exception($"the customer  Id : {id} is not founded.");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
