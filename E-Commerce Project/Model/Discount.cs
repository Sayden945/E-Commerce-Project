using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal DiscountPercent { get; set; }

    public byte Active { get; set; }
}
