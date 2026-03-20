using System;
using System.Collections.Generic;

namespace Entity_Movil_2.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Apelido { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Perfil { get; set; } = null!;

    public bool Bloqueado { get; set; }
}
