﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models
{
	public class CartItem
	{
		public int Id { get; set; }
		public int SessionId { get; set; }
		public string UserId { get; set; }
		public int? Quantity { get; set; }
		public DateTime Created { get; set; }

		public virtual User User { get; set; }
	}
}