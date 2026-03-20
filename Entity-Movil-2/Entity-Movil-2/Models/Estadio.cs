using System;
using System.Collections.Generic;

namespace Entity_Movil_2.Models;

public partial class Estadio
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
