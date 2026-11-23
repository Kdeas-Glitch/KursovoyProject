using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class ClientPet
{
    public int IdPet { get; set; }

    public int IdClient { get; set; }

    public int IdType { get; set; }

    public int IdBreed { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Breed IdBreedNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual TypeAnimal IdTypeNavigation { get; set; } = null!;
}
