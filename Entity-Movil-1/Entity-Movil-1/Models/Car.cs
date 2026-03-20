using System;
using System.Collections.Generic;

namespace Entity_Movil_1.Models;

public partial class Car
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int ModelId { get; set; }

    public int RentalsAverageByMonth { get; set; }

    public decimal HourPrice { get; set; }

    public string Image { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
