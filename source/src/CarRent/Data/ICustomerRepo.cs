using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public interface ICustomerRepo
    {
        bool SaveChanges();
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomerByName(string name);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }
}