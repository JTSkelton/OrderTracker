using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace OrderTracker.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [Required]
        public string Name { get; set; }

        public int BreadOrder { get; set; }

        public int PasteryOrder { get; set; }

        public DateTime OrderDateCreated { get; set; } = DateTime.Now;

    }
}
