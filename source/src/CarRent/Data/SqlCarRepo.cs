using System.Collections.Generic;
using System.Linq;
using CarRent.Models;

namespace CarRent.Data
{
    public class SqlCarRepo : ICarRepo
    {
        private readonly CarRentContext _context;

        public SqlCarRepo(CarRentContext context)
        {
            _context = context;
        }
        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(p => p.Id == id);
        }
    }
}