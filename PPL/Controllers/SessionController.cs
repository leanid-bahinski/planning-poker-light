using Microsoft.AspNetCore.Mvc;
using PPL.Interfaces;
using PPL.Models;

namespace PPL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController(ISessionService sessionService, ILogger<SessionController> logger)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            return await sessionService.GetSessionsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            return await sessionService.GetSessionAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Session>> CreateSession(Session session)
        {
            await sessionService.CreateSessionAsync(session);
            return CreatedAtAction(nameof(GetSession), new { id = session.SessionId }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, Session session)
        {
            if (id != session.SessionId)
            {
                return BadRequest();
            }

            await sessionService.UpdateSessionAsync(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            await sessionService.DeleteSessionAsync(id);
            return NoContent();
        }
    }
}
