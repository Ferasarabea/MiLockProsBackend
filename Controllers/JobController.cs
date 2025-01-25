using Microsoft.AspNetCore.Mvc;
using MiLockProsBackend.Models;
using MiLockProsBackend.Data;

namespace MiLockProsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly LocksmithDbContext _context;

        public JobController(LocksmithDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateJob([FromBody] Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return Ok(job);
        }

        [HttpPost("update-status/{jobId}")]
        public async Task<IActionResult> UpdateJobStatus(int jobId, [FromBody] string status)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job == null) return NotFound();

            job.Status = status;
            await _context.SaveChangesAsync();
            return Ok("Job status updated.");
        }

        [HttpGet("{jobId}")]
        public async Task<ActionResult<Job>> GetJobById(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobHistory()
        {
            var jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }
    }
}
