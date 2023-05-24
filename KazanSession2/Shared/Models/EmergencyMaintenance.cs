using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class EmergencyMaintenance
{
    public long Id { get; set; }

    public long AssetId { get; set; }

    public long PriorityId { get; set; }

    public string DescriptionEmergency { get; set; } = null!;

    public string OtherConsiderations { get; set; } = null!;

    public DateTime EmreportDate { get; set; }

    public DateTime? EmstartDate { get; set; }

    public DateTime? EmendDate { get; set; }

    public string? EmtechnicianNote { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual ICollection<ChangedPart> ChangedParts { get; set; } = new List<ChangedPart>();

    public virtual Priority Priority { get; set; } = null!;
}
