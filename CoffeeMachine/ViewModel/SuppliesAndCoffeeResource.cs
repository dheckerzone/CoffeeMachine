using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.ViewModel
{
    public class SuppliesAndCoffeeResource
    {
        public OfficePantryResource SelectedPantry { get; set; }

        public List<CoffeeResource> CoffeeList { get; set; }

        public List<SuppliesResource> SuppliesResourceList { get; set; }
    }
}
