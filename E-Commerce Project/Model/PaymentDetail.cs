using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class PaymentDetail
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;
}
