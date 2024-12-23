using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Img
{
    public int ImageId { get; set; }

    public int RegionId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Region Region { get; set; } = null!;
}
