﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class UserAddress
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string State { get; set; }

    public string City { get; set; }

    public string PostalCode { get; set; }

    public virtual User User { get; set; }
}