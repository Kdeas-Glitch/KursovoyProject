using System;
using System.Collections.Generic;

namespace GrumingInterface.Models;

public partial class ClientPet
{
    public int IdPet { get; set; }

    public int IdClient { get; set; }

    public int IdType { get; set; }

    public int IdBreed { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }


}
