using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Landscape
{
    public int LandscapeId { get; set; }

    public string LandscapeType { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;
}
