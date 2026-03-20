using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class LoyaltyProgram
{
    public int CustomerId { get; set; }

    public int Points { get; set; }

    public string MembershipTier { get; set; } = null!;
}
