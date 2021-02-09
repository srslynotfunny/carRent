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
    }
}