using System;
using System.Collections.Generic;
using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        //api/customers
        [HttpGet]
        public ActionResult <IEnumerable<CustomerReadDto>> GetAllCustomers()
        {
            var customerItems = _repository.GetAllCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerItems));
        }

        //api/customers/5
        [HttpGet("{id}", Name="GetCustomerById")]
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

        //api/customer/
        [HttpPost]
        public ActionResult <CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            var customerModel = _mapper.Map<Customer>(customerCreateDto);
            _repository.CreateCustomer(customerModel);
            _repository.SaveChanges();

            var customerReadDto = _mapper.Map<CustomerReadDto>(customerModel);

            return CreatedAtRoute(nameof(GetCustomerById), new {Id = customerReadDto.Id}, customerReadDto);
        }

        //api/customer/{id}
        [HttpPut("{id}")]
        public ActionResult <CustomerReadDto> UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
        {
            var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(customerUpdateDto, customerModelFromRepo);

            _repository.UpdateCustomer(customerModelFromRepo);
            _repository.SaveChanges();
            return Ok(_mapper.Map<CustomerReadDto>(customerModelFromRepo));
        }

        //api/customer/{id}
        [HttpPatch("{id}")]
        public ActionResult <CustomerReadDto> PartialUpdateCustomer(int id, JsonPatchDocument<CustomerUpdateDto> patchDoc)
        {
           var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            var customerToPatch = _mapper.Map<CustomerUpdateDto>(customerModelFromRepo);
            patchDoc.ApplyTo(customerToPatch, ModelState);
            if(!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(customerToPatch, customerModelFromRepo);

            _repository.UpdateCustomer(customerModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<CustomerReadDto>(customerModelFromRepo));
        }

        //api/customers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerModelFromRepo = _repository.GetCustomerById(id);
            if(customerModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCustomer(customerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}