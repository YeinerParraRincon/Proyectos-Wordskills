using System;
using System.Collections.Generic;

namespace API4.Models;

public partial class Ordersese
{
    public long TransactionId { get; set; }

    public long CustomerId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Channel { get; set; } = null!;

    public byte StoreId { get; set; }

    public byte PromotionId { get; set; }

    public double DiscountAmount { get; set; }

    public int Total { get; set; }

    public string Status { get; set; } = null!;

    public int OrderItems { get; set; }
}
