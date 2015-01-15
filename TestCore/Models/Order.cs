﻿using System;

namespace TestCore.Models
{
    public class Order
    {
        public int ProductId { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}