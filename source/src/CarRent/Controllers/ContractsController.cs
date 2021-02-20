using System.Collections.Generic;
using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepo _customer;
        private readonly ICarRepo _car;
        private readonly IReservationRepo _reservation;

        public ContractsController(IContractRepo repository, IMapper mapper, ICustomerRepo customer, ICarRepo car, IReservationRepo reservation)
        {
            _repository = repository;
            _mapper = mapper;
            _customer = customer;
            _car = car;
            _reservation = reservation;
        }

        //private readonly MockContractRepo _repository = new MockContractRepo();

        //api/contracts/
        [HttpGet]
        public ActionResult <IEnumerable<ContractReadDto>> GetAllContracts()
        {
            var contractItems = _repository.GetAllContracts();
            return Ok(_mapper.Map<IEnumerable<ContractReadDto>>(contractItems));
        }

        //api/contracts/{id}
        [HttpGet("{id}", Name="GetContractById")]
        public ActionResult <ContractReadDto> GetContractById(int id)
        {
            var contractItem = _repository.GetContractById(id);
            if(contractItem != null)
            {
                return Ok(_mapper.Map<ContractReadDto>(contractItem));
            }
            return NotFound();
        }

        public Contract InformationFill(Contract contractToFill)
        {
            var contract = contractToFill;
            /*if(_repository.GetContractById(contract.Id) == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }
            if(_customer.GetCustomerById(contract.CustomerId) == null)
            {
                throw new ArgumentNullException(nameof(contract.CustomerId));
            }
            if(_car.GetCarById(contract.CarId) == null)
            {
                throw new ArgumentNullException(nameof(contract.CarId));
            }
            if(_reservation.GetReservationById(contract.ReservationId) == null)
            {
                throw new ArgumentNullException(nameof(contract.ReservationId));
            }*/
            var customerModel = _customer.GetCustomerById(contract.CustomerId);
            var carModel = _car.GetCarById(contract.CarId);
            var reservationModel = _reservation.GetReservationById(contract.ReservationId);

            contract.Name = customerModel.FirstName + " " + customerModel.LastName;
            contract.Street = customerModel.Street;
            contract.City = customerModel.City;
            contract.Postalcode = customerModel.Postalcode;

            contract.Manufacturer = carModel.Manufacturer;
            contract.Model = carModel.Model;
            contract.Class = carModel.Class;
            contract.PricePerDay = carModel.PricePerDay;

            contract.BeginDate = reservationModel.BeginDate;
            contract.EndDate = reservationModel.EndDate;
            contract.Costs = reservationModel.Costs;

            carModel.Reserved = true;
            _car.SaveChanges();
            _customer.SaveChanges();
            _reservation.SaveChanges();
            _repository.SaveChanges();

            return contract;
        }

        //api/contracts/
        [HttpPost]
        public ActionResult <ContractReadDto> CreateContract(ContractCreateDto contractCreateDto)
        {
            var contractModel = _mapper.Map<Contract>(contractCreateDto);
            contractModel = InformationFill(contractModel);
            //additional checks etc
            Console.WriteLine(contractCreateDto.CustomerId);

            //var customerModel = _customer.GetCustomerById(2);

            //var carModel = _car.GetCarById(contractCreateDto.CarId);


            //Console.WriteLine(customerModel.Id);
            //var reservationModel = _reservation.GetReservationById(contractModel.ReservationId);
            //contractModel.Name = customerModel.FirstName;

            /*
            contractModel.Name = customerModel.FirstName + " " + customerModel.LastName;
            
            contractModel.Street = customerModel.Street;
            contractModel.City = customerModel.City;
            contractModel.Postalcode = customerModel.Postalcode;

            contractModel.Manufacturer = carModel.Manufacturer;
            contractModel.Model = carModel.Model;
            contractModel.Class = carModel.Class;
            contractModel.PricePerDay = carModel.PricePerDay;

            contractModel.BeginDate = reservationModel.BeginDate;
            contractModel.EndDate = reservationModel.EndDate;
            contractModel.Costs = reservationModel.Costs;

            carModel.Reserved = true;
            _car.SaveChanges();*/

            _repository.CreateContract(contractModel);
            _repository.SaveChanges();

            var contractReadDto = _mapper.Map<ContractReadDto>(contractModel);

            return CreatedAtRoute(nameof(GetContractById), new {Id= contractReadDto.Id}, contractReadDto);
        }

        //api/contracts/{id}
        [HttpPatch("{id}")]
        public ActionResult <ContractReadDto> PartialUpdateContract(int id, JsonPatchDocument<ContractUpdateDto> patchdoc)
        {
            var contractModelFromRepo = _repository.GetContractById(id);
            if(contractModelFromRepo == null)
            {
                return NotFound();
            }

            var contractToPatch = _mapper.Map<ContractUpdateDto>(contractModelFromRepo);
            patchdoc.ApplyTo(contractToPatch, ModelState);
            if(!TryValidateModel(contractToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(contractToPatch, contractModelFromRepo);

            _repository.UpdateContract(contractModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<ContractReadDto>(contractModelFromRepo));
        }

        //api/contracts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContract(int id)
        {
            var contractModelFromRepo = _repository.GetContractById(id);
            if(contractModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteContract(contractModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}