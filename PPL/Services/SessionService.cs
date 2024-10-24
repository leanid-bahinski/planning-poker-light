using Microsoft.EntityFrameworkCore;
using PPL.Interfaces;
using PPL.Models;

namespace PPL.Services
{
    public class SessionService(PplDatabaseContext context) : ISessionService
    {
        public Task<List<Session>> GetSessionsAsync()
        {
            return context.Sessions.ToListAsync();
        }

        public async Task<Session> GetSessionAsync(int id)
        {
            var session = await context.Sessions.FindAsync(id);
            return session ?? throw new KeyNotFoundException();
        }

        public async Task UpdateSessionAsync(Session session)
        {
            context.Entry(session).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task CreateSessionAsync(Session session)
        {
            context.Sessions.Add(session);
            await context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(int id)
        {
            var session = await context.Sessions.FindAsync(id);

            if (session != null)
            {
                context.Sessions.Remove(session);
                await context.SaveChangesAsync();
            }
        }
    }
}
