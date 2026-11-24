using System;
using System.Collections.Generic;

namespace GrumingInterface.Models;

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
}
