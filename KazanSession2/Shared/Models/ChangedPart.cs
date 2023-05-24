using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class ChangedPart
{
    public long Id { get; set; }

    public long EmergencyMaintenanceId { get; set; }

    public long PartId { get; set; }

    public decimal Amount { get; set; }

    public virtual EmergencyMaintenance EmergencyMaintenance { get; set; } = null!;

    public virtual Part Part { get; set; } = null!;
}
