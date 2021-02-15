using System.Collections.Generic;
using System.Linq;
using CarRent.Models;

namespace CarRent.Data
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly CarRentContext _context;

        public SqlCustomerRepo(CarRentContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public Customer GetCustomerByName(string name)
        {
            //currently only possible with lastname
            return _context.Customers.FirstOrDefault(p => p.LastName == name);
        }
    }
}