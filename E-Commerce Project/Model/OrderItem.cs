using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class OrderItem
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
