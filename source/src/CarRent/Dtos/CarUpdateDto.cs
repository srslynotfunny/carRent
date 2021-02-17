using System.ComponentModel.DataAnnotations;

namespace CarRent.Dtos
{
    public class CarUpdateDto
    {
        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string Class { get; set; }
    }
}