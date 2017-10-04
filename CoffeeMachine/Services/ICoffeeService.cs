using CoffeeMachine.ViewModel;
using System.Collections.Generic;

namespace CoffeeMachine.Services
{
  public interface ICoffeeService
    {
        void Add(CoffeeResource drink);

        CoffeeResource GetByName(string name);

        List<CoffeeResource> GetAll();

        List<CoffeeResource> RefillAll();
    }
}
