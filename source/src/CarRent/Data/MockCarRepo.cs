using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public class MockCarRepo : ICarRepo
    {
        public void CreateCar(Car car)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            var cars = new List<Car>
            {
                new Car{Id=0, Manufacturer="BMW", Model="M2", Class="luxury"},
                new Car{Id=1, Manufacturer="Audi", Model="A4", Class="medium"},
                new Car{Id=2, Manufacturer="Fiat", Model="500", Class="easy"}
            };

            return cars;
        }

        public Car GetCarById(int id)
        {
            return new Car{Id=0, Manufacturer="BMW", Model="M2", Class="luxury"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new System.NotImplementedException();
        }
    }
}