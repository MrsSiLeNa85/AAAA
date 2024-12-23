using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public int KingdomId { get; set; }

    public virtual Kingdom Kingdom { get; set; } = null!;
}
