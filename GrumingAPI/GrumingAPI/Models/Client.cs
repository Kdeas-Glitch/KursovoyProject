using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string Fio { get; set; } = null!;

    public int? Number { get; set; }

    public int VkId { get; set; }

    public string? Comment { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<ClientPet> ClientPets { get; set; } = new List<ClientPet>();
}
