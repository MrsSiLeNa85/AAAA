using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class NeighRegion
{
    public int RegionId { get; set; }

    public int RegionId1 { get; set; }

    public int RegionId2 { get; set; }

    public int RegionId3 { get; set; }

    public virtual Region RegionId1Navigation { get; set; } = null!;
}
