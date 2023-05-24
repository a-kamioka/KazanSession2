using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class Asset
{
    public long Id { get; set; }

    public string AssetSn { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public long DepartmentLocationId { get; set; }

    public long EmployeeId { get; set; }

    public long AssetGroupId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? WarrantyDate { get; set; }

    public virtual AssetGroup AssetGroup { get; set; } = null!;

    public virtual DepartmentLocation DepartmentLocation { get; set; } = null!;

    public virtual ICollection<EmergencyMaintenance> EmergencyMaintenances { get; set; } = new List<EmergencyMaintenance>();

    public virtual Employee Employee { get; set; } = null!;
}
