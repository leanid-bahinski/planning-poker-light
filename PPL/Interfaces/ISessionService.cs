using PPL.Models;

namespace PPL.Interfaces
{
    public interface ISessionService
    {
        Task<List<Session>> GetSessionsAsync();
        Task<Session> GetSessionAsync(int id);
        Task CreateSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task DeleteSessionAsync(int id);
    }
}
