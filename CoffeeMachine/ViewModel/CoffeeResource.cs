using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.ViewModel
{
    public class CoffeeResource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int UnitsOfBeans { get; set; }

        public int UnitsOfSugar { get; set; }

        public int UnitsOfMilk { get; set; }
    }
}
