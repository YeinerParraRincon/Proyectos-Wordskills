using System;
using System.Collections.Generic;

namespace Apis2.Models;

public partial class OrderItemse
{
    public long OrdersItems { get; set; }

    public long TransactionId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public virtual Producto Product { get; set; } = null!;
}
