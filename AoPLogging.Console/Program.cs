using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCore.InfraStructure;
using TestCore.Interfaces;
using TestCore.Managers;
using TestCore.Models;

namespace AoPLogging.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor proc = new Processor();
            proc.Order();
            proc.StartTransaction();
          //  System.Console.ReadKey();
        }
    }

    class Processor
    {
       // private static ILogger __logger;
        private  IOrderProcessor __order;

        public Processor()
        {
           // __logger = new LoggerManager();
          //  __logger = IoC.Resolve<ILogger>();
            //__order = new OrderService();
            __order = IoC.Resolve<IOrderProcessor>();

        }

        public void Order()
        {
            Order order = new Order();
            order.ProductId = 1;
            order.Discount = 10;
            order.Price = 100;
            order.OrderDate = DateTime.Now;
            order.Quantity = 2;

            bool isSuccess = __order.ProcessOrder(order);
        }

        public void StartTransaction()
        {
            System.Console.WriteLine("starttransaction method has been called!");
            //__logger.Info("StartTransaction has been started.");
            //__logger.Debug("StartTransaction","debug mode");
        } 

        public void DoSomething()
        {

        }

        public void StopTransaction()
        {
            //__logger.Info("Transaction stopped");
        }
    }


}
