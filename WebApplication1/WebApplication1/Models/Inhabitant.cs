using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Inhabitant
{
    public int InhabitantId { get; set; }

    public int KingdomId { get; set; }

    public string Name { get; set; } = null!;

    public int Population { get; set; }

    public virtual Kingdom Kingdom { get; set; } = null!;
}
