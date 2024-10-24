﻿using System.ComponentModel.DataAnnotations;

namespace PPL.Models;

public sealed partial class Session
{
    public int SessionId { get; init; }

    [MaxLength(128)]
    public string? Name { get; init; }

    public DateTime? StartDate { get; init; }

    [MaxLength(1024)]
    public string? Description { get; init; }

    public ICollection<SessionUser> SessionUsers { get; init; } = new List<SessionUser>();
}
