using System;
using System.Collections.Generic;

namespace CoffeeMachine.ViewModel
{
  public class OrderResource
    {
        public OrderResource()
        {
            SuppliesAndCoffeeResource = new SuppliesAndCoffeeResource();
            OfficePantryList = new List<OfficePantryResource>();
            SelectedOfficePantry = new OfficePantryResource();
        }

        public Guid Id { get; set; }

        public CoffeeResource SelectedCoffee { get; set; }

        public List<OfficePantryResource> OfficePantryList { get; set; }

        public OfficePantryResource SelectedOfficePantry { get; set; }

        public SuppliesAndCoffeeResource SuppliesAndCoffeeResource { get; set; }

        public DateTime OrderDate { get; set; }

        public List<CoffeeResource> CoffeeList { get; set; }
  }
}
