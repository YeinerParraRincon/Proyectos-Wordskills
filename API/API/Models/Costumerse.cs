using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Costumerse
{
    public long CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public int Gender { get; set; }

    public int PostalCode { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string MembershipStatus { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateOnly LastPurchaseDate { get; set; }

    public int TotalSpending { get; set; }

    public int AverageOrderValue { get; set; }

    public byte Frequency { get; set; }

    public string PreferredCategory { get; set; } = null!;

    public bool Churned { get; set; }
}
