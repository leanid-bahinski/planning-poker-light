using System;
using System.Collections.Generic;

namespace PPL.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
}
