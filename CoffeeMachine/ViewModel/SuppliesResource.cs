using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.ViewModel
{
    public class SuppliesResource
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public int Units { get; set; }

        public OfficePantryResource OfficePantry { get; set; }
    }
}
