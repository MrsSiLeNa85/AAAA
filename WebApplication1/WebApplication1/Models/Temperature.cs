using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Temperature
{
    public int TemperatureId { get; set; }

    public int RegionId { get; set; }

    public string Season { get; set; } = null!;

    public int AverageTemperature { get; set; }

    public virtual Region Region { get; set; } = null!;
}
