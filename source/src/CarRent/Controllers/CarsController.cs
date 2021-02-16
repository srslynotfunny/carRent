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
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _repository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //private readonly MockCarRepo _repository = new MockCarRepo();

        //api/cars
        [HttpGet]
        public ActionResult <IEnumerable<CarReadDto>> GetAllCars()
        {
            var carItems = _repository.GetAllCars();
            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(carItems));
        }

        //api/cars/5
        [HttpGet("{id}")]
        public ActionResult <CarReadDto> GetCarById(int id)
        {
            var carItem = _repository.GetCarById(id);
            if(carItem != null)
            {
                return Ok(_mapper.Map<CarReadDto>(carItem));
            }
            return NotFound();
        }

        //api/cars
        [HttpPost]
        public ActionResult <CarReadDto> CreateCar(CarCreateDto carCreateDto)
        {
            var carModel = _mapper.Map<Car>(carCreateDto);
            switch (carModel.Class.ToString())
            {
                case "Luxury":
                    carModel.PricePerDay = 100;
                    break;
                case "Medium":
                    carModel.PricePerDay = 60;
                    break;
                case "Easy":
                    carModel.PricePerDay = 40;
                    break;
                default:
                    return BadRequest();
            }
            _repository.CreateCar(carModel);
            _repository.SaveChanges();

            return (_mapper.Map<CarReadDto>(carModel));
        }
    }
}