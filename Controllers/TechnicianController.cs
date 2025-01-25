using Microsoft.AspNetCore.Mvc;
using MiLockProsBackend.Models;
using MiLockProsBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace MiLockProsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicianController : ControllerBase
    {
        private readonly LocksmithDbContext _context;

        public TechnicianController(LocksmithDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Technician technician)
        {
            if (_context.Technicians.Any(t => t.Email == technician.Email))
            {
                return BadRequest("Email already exists.");
            }

            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync();
            return Ok("Technician signed up successfully.");
        }

        [HttpPost("login")]
        public async Task<ActionResult<Technician>> Login([FromBody] Technician technician)
        {
            var user = await _context.Technicians
                .FirstOrDefaultAsync(t => t.Email == technician.Email && t.Password == technician.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok(user);
        }

        [HttpGet("profit/{technicianId}")]
        public async Task<ActionResult<decimal>> GetTechnicianProfit(int technicianId)
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);

            // Sum the JobAmount for all jobs completed by this technician in the past week
            var profit = await _context.Jobs
                .Where(j => j.TechnicianId == technicianId && j.Status == "Completed" && j.CompletionDate >= oneWeekAgo)
                .SumAsync(j => j.JobAmount);

            return Ok(profit);
        }
    }
}

