using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class OrderDetail
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public decimal Total { get; set; }

    public int PaymentId { get; set; }
}
