using System;
using System.Collections.Generic;

namespace KazanSession2.Shared.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool? IsAdmin { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
