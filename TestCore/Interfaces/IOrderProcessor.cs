using TestCore.Models;

namespace TestCore.Interfaces
{
  public  interface IOrderProcessor
    {
        bool ProcessOrder(Order newOrder);
    }
}
