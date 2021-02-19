using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Dtos
{
    public class ReservationUpdateDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}