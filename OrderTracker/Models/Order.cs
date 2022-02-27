using System.ComponentModel.DataAnnotations;

namespace OrderTracker.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int BreadOrder { get; set; }

        public int PasteryOrder { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
