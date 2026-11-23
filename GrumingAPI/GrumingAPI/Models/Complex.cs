using System;
using System.Collections.Generic;

namespace GrumingAPI.Models;

public partial class Complex
{
    public int IdComp { get; set; }

    public int Name { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ICollection<Service> IdServices { get; set; } = new List<Service>();
}
