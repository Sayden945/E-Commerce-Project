using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Sku { get; set; }

    public int CategoryId { get; set; }

    public int InventoryId { get; set; }

    public decimal Price { get; set; }

    public int? DiscountId { get; set; }
}
