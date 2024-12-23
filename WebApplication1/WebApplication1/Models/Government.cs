using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Government
{
    public int GovernmentId { get; set; }

    public int KingdomId { get; set; }

    public string LeaderName { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public virtual Kingdom Kingdom { get; set; } = null!;
}
