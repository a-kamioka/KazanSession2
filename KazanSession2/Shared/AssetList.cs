using System;
using System.Collections.Generic;
using KazanSession2.Shared.Models;

namespace KazanSession2.Shared;

public partial class AssetList
{
    public long Id { get; set; }

    public string AssetSn { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public DateTime? EmendDate { get; set; }

    public long? ClosedNumber { get; set; }

    public long? EmNumber { get; set; } 
}
