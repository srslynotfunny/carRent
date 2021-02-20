namespace CarRent.Dtos
{
    public class ContractCreateDto
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int ReservationId { get; set; }
    }
}