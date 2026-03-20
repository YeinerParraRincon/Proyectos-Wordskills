using System;
using System.Collections.Generic;

namespace Prueba_Entity_2.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int? CarId { get; set; }

    public int NotificationTypeId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual NotificationType NotificationType { get; set; } = null!;
}
