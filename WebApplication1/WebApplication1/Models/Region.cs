using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Climate { get; set; } = null!;

    public virtual ICollection<Img> Imgs { get; set; } = new List<Img>();

    public virtual ICollection<Kingdom> Kingdoms { get; set; } = new List<Kingdom>();

    public virtual ICollection<Landscape> Landscapes { get; set; } = new List<Landscape>();

    public virtual ICollection<NeighRegion> NeighRegions { get; set; } = new List<NeighRegion>();

    public virtual ICollection<Temperature> Temperatures { get; set; } = new List<Temperature>();
}
