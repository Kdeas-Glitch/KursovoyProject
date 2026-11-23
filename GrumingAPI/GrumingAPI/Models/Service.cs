using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class Service
{
    public int IdService { get; set; }

    public string Name { get; set; } = null!;

    public int Time { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Complex> IdComps { get; set; } = new List<Complex>();
}
