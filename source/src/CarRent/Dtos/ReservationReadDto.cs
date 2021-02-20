using System;

namespace CarRent.Dtos
{
    public class ReservationReadDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CarClass { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Costs { get; set; }
    }
}