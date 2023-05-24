using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class Location
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<DepartmentLocation> DepartmentLocations { get; set; } = new List<DepartmentLocation>();
}
