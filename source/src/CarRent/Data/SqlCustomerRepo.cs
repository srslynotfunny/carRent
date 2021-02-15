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

        public IEnumerable<Customer> GetCustomerByName(string name)
        {
            List<Customer> list = _context.Customers.ToList();
            List<Customer> alteredList = new List<Customer>();

            foreach(Customer customer in list)
            {
                if (customer.FirstName.ToLower() == name.ToLower() || customer.LastName.ToLower() == name.ToLower())
                {
                    alteredList.Add(customer);
                }
            }
            return alteredList;
        }
    }
}