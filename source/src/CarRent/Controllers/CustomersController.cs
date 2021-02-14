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

        //api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customerItems = _repository.GetAllCustomers();
            return Ok(customerItems);
        }

        //api/customers/id?5
        [HttpGet("id")]
        public ActionResult<Customer> GetCustomerById([FromQuery]int id)
        {
            var customerItem = _repository.GetCustomerById(id);
            return Ok(customerItem);
        }

        //api/customers/name?peter
        [HttpGet("name")]
        public ActionResult<Customer> GetCustomerByName([FromQuery]string name)
        {
            var customerItem = _repository.GetCustomerByName(name);
            return Ok(customerItem);
        }
    }
}