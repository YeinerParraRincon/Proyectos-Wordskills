using System;
using System.Collections.Generic;

namespace Entity_Movil_2.Models;

public partial class Selecao
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public byte[]? Bandeira { get; set; }

    public virtual ICollection<Jogador> Jogadors { get; set; } = new List<Jogador>();

    public virtual ICollection<Jogo> JogoSelecaoCasaNavigations { get; set; } = new List<Jogo>();

    public virtual ICollection<Jogo> JogoSelecaoVisitanteNavigations { get; set; } = new List<Jogo>();
}
