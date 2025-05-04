
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public AccountsController(CustomerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            var customer = await _context.Customers.FindAsync(account.CustomerId);
            if (customer == null) return NotFound("Customer not found.");

            account.CreationTimestamp = DateTime.UtcNow;
            account.UpdatedTimestamp = DateTime.UtcNow;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();
            return account;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account updated)
        {
            if (id != updated.AccountId) return BadRequest();

            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();

            account.Status = updated.Status;
            account.Balance = updated.Balance;
            account.UpdatedTimestamp = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
