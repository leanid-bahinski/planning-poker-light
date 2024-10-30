using PPL.Models;

namespace PPL.Interfaces
{
    public interface ISessionUserService
    {
        Task<List<SessionUser>> GetSessionUsersAsync();
        Task<List<SessionUser>> GetSessionUserBySessionIdAsync(int sessionId);
        Task<SessionUser> GetSessionUserAsync(int id);
        Task CreateSessionUserAsync(SessionUser sessionUser);
        Task UpdateSessionUserAsync(SessionUser sessionUser);
        Task DeleteSessionUserAsync(int id);
    }
}
