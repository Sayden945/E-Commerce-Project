using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class CartItem
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public string UserId { get; set; } = null!;

    public int? Quantity { get; set; }

    public DateTime Created { get; set; }
}
