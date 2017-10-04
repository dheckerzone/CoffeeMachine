using CoffeeMachine.ViewModel;
using System.Collections.Generic;

namespace CoffeeMachine.Services
{
  public interface IOrderService
    {
        void Save(SaveOrderResource order);

        List<OrderHistoryResource> GetOrderHistory();
    }
}
