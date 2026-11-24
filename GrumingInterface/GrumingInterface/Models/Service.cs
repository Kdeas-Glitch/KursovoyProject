using System;
using System.Collections.Generic;

namespace GrumingInterface.Models;

public partial class Service
{
    public int IdService { get; set; }

    public string Name { get; set; } = null!;

    public int Time { get; set; }

    public int Price { get; set; }

}
