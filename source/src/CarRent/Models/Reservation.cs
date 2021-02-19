using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public string CarClass { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int Costs { get; set; }
    }
}