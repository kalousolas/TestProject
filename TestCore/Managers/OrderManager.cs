using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCore.Interfaces;
using TestCore.Models;

namespace TestCore.Managers
{
    public class OrderManager : IOrderProcessor
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