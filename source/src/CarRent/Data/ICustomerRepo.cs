using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByName(string name);

    }
}