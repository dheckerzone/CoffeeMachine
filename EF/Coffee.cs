using System;
using System.ComponentModel.DataAnnotations;

namespace EF
{
    public class Coffee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UnitsOfBeans { get; set; }

        public int UnitsOfSugar { get; set; }

        public int UnitsOfMilk { get; set; }
    }
}