using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class ShoppingSession
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? Total { get; set; }

    public DateTime Created { get; set; }
}
