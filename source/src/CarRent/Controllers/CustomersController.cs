using System;
using System.Collections.Generic;
using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCustomerRepo _repository = new MockCustomerRepo();

        //api/customers
        [HttpGet]
        public ActionResult <IEnumerable<CustomerReadDto>> GetAllCustomers()
        {
            var customerItems = _repository.GetAllCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerItems));
        }

        //api/customers/5
        [HttpGet("{id}")]
        public ActionResult <CustomerReadDto> GetCustomerById(int id)
        {
            var customerItem = _repository.GetCustomerById(id);
            if(customerItem != null)
            {
                return Ok(_mapper.Map<CustomerReadDto>(customerItem));
            }
            return NotFound();
        }

        //api/customers/name/peter
        [HttpGet("name/{name}")]
        public ActionResult <IEnumerable<CustomerReadDto>> GetCustomerByName(string name)
        {
            var customerItems = _repository.GetCustomerByName(name);
            
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerItems));
        }

        /*
        //GET api/ControllerName?p1=1&p2=2&p3=3&p4=4&p5=5
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetItemByNameAndId(string p1, string p2, string p3, string p4, string p5) {​​
            //...return Ok(someResult);
        }​​*/
    }
}