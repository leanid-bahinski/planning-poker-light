using System.ComponentModel.DataAnnotations;

namespace PPL.Models;

public sealed partial class SessionUser
{
    public int SessionUserId { get; init; }

    public int? SessionId { get; init; }

    [MaxLength(128)]
    public string? Name { get; init; }

    public DateTime? StartDate { get; init; }

    public int? Vote { get; init; }

    public DateTime? VoteDate { get; init; }

    public Session? Session { get; init; }
}
