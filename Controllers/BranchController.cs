using Bank_mangement_system.DTOs;
using Bank_mangement_system.Rpos.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_mangement_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo _brachrepo;
        public BranchController(IBranchRepo branchRepo)
        {
            _brachrepo = branchRepo;
        }
        [HttpPost]
        public IActionResult AddBrachwihtCustomer(BranchCustomerDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Branch data must  provided.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _brachrepo.AddBranchCustomers(dto);
                return Ok("Successful.");

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Getall()
        {
            try
            {
                var branch = _brachrepo.GetAllBranches();
                if (branch == null)
                    return NotFound();
                return Ok(branch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Editbranchcustomers(int id, BranchCustomerDto dto)
        {
            try
            {
                _brachrepo.Updata(id, dto);
                return Ok("Updated. ");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletebarach(int id)
        {
            try
            {
                _brachrepo.DeleteBrach(id);
                return Ok("Deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
