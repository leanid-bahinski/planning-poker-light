using Microsoft.AspNetCore.Mvc;
using PPL.Interfaces;
using PPL.Models;

namespace PPL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionUserController(ISessionUserService sessionUserService, ILogger<SessionUserController> logger)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionUser>>> GetSessionUsers()
        {
            return await sessionUserService.GetSessionUsersAsync();
        }

        [HttpGet("Session/{sessionId}")]
        public async Task<ActionResult<IEnumerable<SessionUser>>> GetSessionUserBySessionId(int sessionId)
        {
            return await sessionUserService.GetSessionUserBySessionIdAsync(sessionId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionUser>> GetSessionUser(int id)
        {
            return await sessionUserService.GetSessionUserAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<SessionUser>> CreateSessionUser(SessionUser sessionUser)
        {
            await sessionUserService.CreateSessionUserAsync(sessionUser);
            return CreatedAtAction(nameof(GetSessionUser), new { id = sessionUser.SessionUserId }, sessionUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSessionUser(int id, SessionUser sessionUser)
        {
            if (id != sessionUser.SessionUserId)
            {
                return BadRequest();
            }

            await sessionUserService.UpdateSessionUserAsync(sessionUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionUser(int id)
        {
            await sessionUserService.DeleteSessionUserAsync(id);
            return NoContent();
        }
    }
}
