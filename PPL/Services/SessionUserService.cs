using Microsoft.EntityFrameworkCore;
using PPL.Interfaces;
using PPL.Models;

namespace PPL.Services
{
    public class SessionUserService(PplDatabaseContext context) : ISessionUserService
    {
        public Task<List<SessionUser>> GetSessionUsersAsync()
        {
            return context.SessionUsers.ToListAsync();
        }

        public Task<List<SessionUser>> GetSessionUserBySessionIdAsync(int sessionId)
        {
            return context.SessionUsers
                .Where(x => x.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<SessionUser> GetSessionUserAsync(int id)
        {
            var sessionUser = await context.SessionUsers.FindAsync(id);
            return sessionUser ?? throw new KeyNotFoundException();
        }

        public async Task UpdateSessionUserAsync(SessionUser sessionUser)
        {
            context.Entry(sessionUser).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task CreateSessionUserAsync(SessionUser sessionUser)
        {
            context.SessionUsers.Add(sessionUser);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSessionUserAsync(int id)
        {
            var sessionUser = await context.SessionUsers.FindAsync(id);

            if (sessionUser != null)
            {
                context.SessionUsers.Remove(sessionUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
