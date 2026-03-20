using System;
using System.Collections.Generic;

namespace Entity_Movil_2.Models;

public partial class Imagen
{
    public int Codigo { get; set; }

    public byte[]? Arquivo { get; set; }

    public virtual Jogador CodigoNavigation { get; set; } = null!;
}
