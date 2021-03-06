﻿using TestCore.Interfaces;
using TestCore.Models;

namespace TestCore.Services
{
    public class OrderService : IOrderProcessor
    {
        public bool ProcessOrder(Order newOrder)
        {
            if (newOrder.Discount>10)
            {
                return false;
            }
            return true;
        }
    }
}