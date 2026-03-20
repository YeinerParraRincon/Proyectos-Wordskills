using System;
using System.Collections.Generic;

namespace Entity_Movil_2.Models;

public partial class Jogador
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime Nascimento { get; set; }

    public string Posicao { get; set; } = null!;

    public int? Qtdefaltas { get; set; }

    public int? QtdecartoesAmarelo { get; set; }

    public int? QtdecartoesVermelho { get; set; }

    public int? Qtdegols { get; set; }

    public string? Informacoes { get; set; }

    public int? NumeroCamisa { get; set; }

    public int? SelecaoId { get; set; }

    public virtual Imagen? Imagen { get; set; }

    public virtual Selecao? Selecao { get; set; }
}
