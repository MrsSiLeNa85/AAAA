using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Kingdom
{
    public int KingdomId { get; set; }

    public string KingdomName { get; set; } = null!;

    public int RegionId { get; set; }

    public int GovernmentId { get; set; }

    public string Language { get; set; } = null!;

    public string Trading { get; set; } = null!;

    public virtual ICollection<Government> Governments { get; set; } = new List<Government>();

    public virtual ICollection<Inhabitant> Inhabitants { get; set; } = new List<Inhabitant>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();
}
