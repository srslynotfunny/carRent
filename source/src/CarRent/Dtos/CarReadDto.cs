namespace CarRent.Dtos
{
    public class CarReadDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int PricePerDay { get; set; }
        public bool Reserved { get; set; }
    }
}