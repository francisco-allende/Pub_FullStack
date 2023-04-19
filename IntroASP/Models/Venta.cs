using System;
using System.Collections.Generic;

namespace IntroASP.Models;

public partial class Venta
{
    public int IdClient { get; set; }

    public int IdBeer { get; set; }

    public int Cantidad { get; set; }

    public virtual Beer IdBeerNavigation { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}
