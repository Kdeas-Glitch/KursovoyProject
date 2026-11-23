using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class TypeAnimal
{
    public int IdType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClientPet> ClientPets { get; set; } = new List<ClientPet>();
}
