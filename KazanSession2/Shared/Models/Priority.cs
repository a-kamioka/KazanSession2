using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class Priority
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EmergencyMaintenance> EmergencyMaintenances { get; set; } = new List<EmergencyMaintenance>();
}
