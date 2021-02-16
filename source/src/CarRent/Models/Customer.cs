using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

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