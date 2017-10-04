using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Coffee")]
        public Guid CoffeeId { get; set; }

        public Coffee Coffee { get; set; }

        [ForeignKey("Pantry")]
        public Guid PantryId { get; set; }

        public Pantry Pantry { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
