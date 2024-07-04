using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Repository;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public BalancesController( IUnitOfWork unitOfWork, IMapper mapper)
        {
       
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/balances/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBalanceByUserId(Guid userId)
        {
            var balance = await _unitOfWork.Balances.GetByUserIdAsync(userId);
            if (balance == null)
            {
                return NotFound();
            }

            var balanceDTO = _mapper.Map<BalanceDTO>(balance);
            return Ok(balanceDTO);
        }

        // PUT: api/balances/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateBalance(Guid userId, [FromBody] Balance balance)
        {
            if (balance == null || balance.UserId != userId)
            {
                return BadRequest();
            }

            var existingBalance = await _unitOfWork.Balances.GetByUserIdAsync(userId);
            if (existingBalance == null)
            {
                return NotFound();
            }

            existingBalance.Amount = balance.Amount; // Update relevant fields
            // Add other fields to update if needed

            try
            {
                await _unitOfWork.Balances.UpdateBalanceAsync(existingBalance);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while updating the balance.");
            }

            return NoContent();
        }

        // POST: api/balances
        [HttpPost]
        public async Task<IActionResult> CreateBalance([FromBody] Balance balance)
        {
            if (balance == null)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.Balances.AddAsync(balance);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the balance.");
            }

            return CreatedAtAction(nameof(GetBalanceByUserId), new { userId = balance.UserId }, balance);
        }

        // DELETE: api/balances/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteBalance(Guid userId)
        {
            var balance = await _unitOfWork.Balances.GetByUserIdAsync(userId);
            if (balance == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.Balances.Delete(balance);
                await _unitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the balance.");
            }

            return NoContent();
        }
    }
}
