using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class Breed
{
    public int IdBreed { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Наценка
    /// </summary>
    public int Markup { get; set; }

    /// <summary>
    /// Доп время
    /// </summary>
    public int AddTime { get; set; }

    public virtual ICollection<ClientPet> ClientPets { get; set; } = new List<ClientPet>();
}
