using System;
using System.Collections.Generic;

namespace PresentationWebProject.Models;

public partial class Presentation
{
    public int IdPresent { get; set; }

    public string? Title { get; set; }

    public int? TeacherId { get; set; }

    public string? Prewiew { get; set; }

    public string? PresentationFileName { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
