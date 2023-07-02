using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Model;

public partial class UserAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
