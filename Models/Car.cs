using System.ComponentModel.DataAnnotations;

namespace CarManufacturersMVC.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Class { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string ProductionYears { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? PhotoUrl { get; set; }
        
        public int ManufacturerId { get; set; }
        
        public Manufacturer? Manufacturer { get; set; }
    }
} 