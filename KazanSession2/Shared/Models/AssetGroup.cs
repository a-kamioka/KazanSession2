using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class AssetGroup
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
