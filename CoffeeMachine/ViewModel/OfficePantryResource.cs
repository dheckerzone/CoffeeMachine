using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMachine.ViewModel
{
    public class OfficePantryResource
    {
        public Guid PantryId { get; set; }

        public string Pantry { get; set; }

        public Guid OfficeId { get; set; }

        public string Office { get; set; }
    }
}
