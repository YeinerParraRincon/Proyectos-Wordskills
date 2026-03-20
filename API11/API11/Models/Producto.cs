using System;
using System.Collections.Generic;

namespace API11.Models;

public partial class Producto
{
    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Ingredients { get; set; } = null!;

    public short Price { get; set; }

    public short Cost { get; set; }

    public bool Seasonal { get; set; }

    public bool Active { get; set; }

    public DateOnly Date { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<OrderItemse> OrderItemses { get; set; } = new List<OrderItemse>();
}
