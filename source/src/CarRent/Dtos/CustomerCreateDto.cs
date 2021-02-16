using System.ComponentModel.DataAnnotations;

namespace CarRent.Dtos
{
    public class CustomerCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Street { get; set; }

        [Required]
        [MaxLength(250)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string Postalcode { get; set; }
    }
}