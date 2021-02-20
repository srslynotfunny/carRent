using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        [Required]
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int PricePerDay { get; set; }
        [Required]
        public int ReservationId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Costs { get; set; }
    }
}