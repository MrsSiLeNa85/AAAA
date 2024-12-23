using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Settlement
{
    public int SettlementId { get; set; }

    public string SettlementName { get; set; } = null!;

    public int KingdomId { get; set; }

    public int Population { get; set; }

    public virtual Kingdom Kingdom { get; set; } = null!;
}
