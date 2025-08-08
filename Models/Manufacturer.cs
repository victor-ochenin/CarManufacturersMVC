using System.ComponentModel.DataAnnotations;

namespace CarManufacturersMVC.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;

        [StringLength(500)]
        public string? PhotoUrl { get; set; }
        
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
} 