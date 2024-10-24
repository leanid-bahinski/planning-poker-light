using System;
using System.Collections.Generic;

namespace PPL.Models;

public partial class SessionUser
{
    public int SessionUserId { get; set; }

    public int? SessionId { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public int? Vote { get; set; }

    public DateTime? VoteDate { get; set; }

    public virtual Session? Session { get; set; }
}
