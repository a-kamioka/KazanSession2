using System;
using System.Collections.Generic;
using KazanSession2.Shared.Models;

namespace KazanSession2.Shared;

public partial class EMList
{
    public long Id { get; set; }

    public string AssetSn { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public DateTime? EmRequestDate { get; set; }

    public string FullName { get; set; } = null!;

    public string Department { get; set; } = null!;
}
