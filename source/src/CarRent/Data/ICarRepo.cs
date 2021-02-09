using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public interface ICarRepo
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
    }
}