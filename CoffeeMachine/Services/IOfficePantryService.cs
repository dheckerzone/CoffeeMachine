using CoffeeMachine.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.Services
{
    public interface IOfficePantryService
    {
        List<OfficePantryResource> GetAll();

        OfficePantryResource Add();
    }
}
