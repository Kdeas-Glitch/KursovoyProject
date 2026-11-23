using System;
using System.Collections;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class History
{
    public int IdHistory { get; set; }

    public int IdComp { get; set; }

    public int IdPet { get; set; }

    public BitArray IsComplete { get; set; } = null!;

    public string? Comment { get; set; }

    public DateOnly PlanDate { get; set; }

    public virtual Complex IdCompNavigation { get; set; } = null!;

    public virtual ClientPet IdPetNavigation { get; set; } = null!;
}
