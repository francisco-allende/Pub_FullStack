using System;
using System.Collections.Generic;

namespace IntroASP.Models;

public partial class Beer
{
    public int Id { get; set; }

    public string Marca { get; set; }

    public string Estilo { get; set; } 

    public string Origen { get; set; } 

    public int Precio { get; set; }
}
