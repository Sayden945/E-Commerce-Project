﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class OrderDetails
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public decimal Total { get; set; }

    public int PaymentId { get; set; }

    public DateTime Created { get; set; }

    public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public virtual PaymentDetails Payment { get; set; }

    public virtual ICollection<PaymentDetails> PaymentDetails { get; set; } = new List<PaymentDetails>();

    public virtual User User { get; set; }
}