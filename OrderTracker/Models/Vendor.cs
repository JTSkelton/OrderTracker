using System.ComponentModel.DataAnnotations;

namespace OrderTracker.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

