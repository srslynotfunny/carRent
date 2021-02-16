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
        private readonly ICustomerRepo _repository;

        public CustomersController(ICustomerRepo repository)
        {
            _repository = repository;
        }

        //private readonly MockCustomerRepo _repository = new MockCustomerRepo();

        //api/customers
        [HttpGet]
        public ActionResult <IEnumerable<Customer>> GetAllCustomers()
        {
            var customerItems = _repository.GetAllCustomers();
            return Ok(customerItems);
        }

        //api/customers/5
        [HttpGet("{id}")]
        public ActionResult <Customer> GetCustomerById(int id)
        {
            var customerItem = _repository.GetCustomerById(id);
            return Ok(customerItem);
        }

        //api/customers/name/peter
        [HttpGet("name/{name}")]
        public ActionResult <IEnumerable<Customer>> GetCustomerByName(string name)
        {
            var customerItems = _repository.GetCustomerByName(name);
            return Ok(customerItems);
        }

        //api/customers
    }
}