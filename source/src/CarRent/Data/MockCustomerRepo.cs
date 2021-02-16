using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public class MockCustomerRepo : ICustomerRepo
    {
        public void CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer{Id=0, FirstName="Hans", LastName="Müller"},
                new Customer{Id=1, FirstName="Klaus", LastName="Schneider"},
                new Customer{Id=2, FirstName="Markus", LastName="Köppel"}
            };

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return new Customer{Id=0, FirstName="Hans", LastName="Müller"};
        }

        public IEnumerable<Customer> GetCustomerByName(string name)
        {
            var customers = new List<Customer>
            {
                new Customer{Id=2, FirstName="Markus", LastName="Köppel"}
            };
            return customers;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}