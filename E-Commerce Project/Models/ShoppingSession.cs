#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class ShoppingSession
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public decimal Total { get; set; }

    public DateTime Created { get; set; }

    public virtual ICollection<CartItem> CartItem { get; set; } = new List<CartItem>();

    public virtual User User { get; set; }
}