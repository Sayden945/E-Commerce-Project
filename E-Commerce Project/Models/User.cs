﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models
{
    public partial class User
    {
        public User()
        {
            CartItem = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetails>();
            ShoppingSession = new HashSet<ShoppingSession>();
            UserAddress = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ShoppingSession> ShoppingSession { get; set; }
        public virtual ICollection<UserAddress> UserAddress { get; set; }
    }
}