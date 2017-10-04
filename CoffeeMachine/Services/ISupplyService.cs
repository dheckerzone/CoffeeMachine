using CoffeeMachine.ViewModel;
using System.Collections.Generic;

namespace CoffeeMachine.Services
{
  public interface ISupplyService
  {
    List<SuppliesResource> Get(string pantry);

    void Update(SaveOrderResource order);

    List<SuppliesResource> Refill(string pantry);
  }
}
