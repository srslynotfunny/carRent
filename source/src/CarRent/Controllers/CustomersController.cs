using System.Collections.Generic;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MockCustomerRepo _repository = new MockCustomerRepo();

        //GET api/customers
        [HttpGet]
        public ActionResult <IEnumerable<Customer>> GetAllCustomers()
        {
             var customerItems = _repository.GetAllCustomers();
             return Ok(customerItems);
        }

        //GET api/customers/{id}
        [HttpGet("{id}", Name="GetCustomerById")]
        public ActionResult <Customer> GetCustomerById(int id)
        {
            var customerItem = _repository.GetCustomerById(id);
            return Ok(customerItem);
        }

        //GET api/customers/{string}
        [Route("api/customer/name")]
        [HttpGet("{name}", Name="GetCustomerByName")]
        public ActionResult <Customer> GetCustomerByName(string name)
        {
            var customerItem = _repository.GetCustomerByName(name);
            return Ok(customerItem);
        }
    }
}