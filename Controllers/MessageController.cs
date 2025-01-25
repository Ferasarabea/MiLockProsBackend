using Microsoft.AspNetCore.Mvc;
using MiLockProsBackend.Models;
using MiLockProsBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace MiLockProsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly LocksmithDbContext _context;

        public MessageController(LocksmithDbContext context)
        {
            _context = context;
        }

        [HttpPost("{jobId}/send")]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Ok("Message sent.");
        }

        [HttpGet("{jobId}/messages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int jobId)
        {
            var messages = await _context.Messages
                                        .Where(m => m.JobId == jobId)
                                        .ToListAsync();
            return Ok(messages);
        }
    }
}
