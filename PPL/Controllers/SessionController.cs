using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPL.Models;

namespace PPL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController(PplDatabaseContext context, ILogger<SessionController> logger)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            return await context.Sessions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return session;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, Session session)
        {
            if (id != session.SessionId)
            {
                return BadRequest();
            }

            context.Entry(session).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Session>> CreateSession(Session session)
        {
            context.Sessions.Add(session);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetSession", new { id = session.SessionId }, session);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            context.Sessions.Remove(session);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionExists(int id)
        {
            return context.Sessions.Any(e => e.SessionId == id);
        }
    }
}
