using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Supply
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Units { get; set; }

        [ForeignKey("Pantry")]
        public Guid PantryId { get; set; }

        public Pantry Pantry { get; set; }
    }
}
