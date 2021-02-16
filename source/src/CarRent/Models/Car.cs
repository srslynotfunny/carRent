using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string Class { get; set; }

        [MaxLength(10)]
        public int PricePerDay { get; set; }
        
    }
}