﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ProductInventory Inventory { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}