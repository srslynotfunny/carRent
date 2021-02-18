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
        [HttpGet("{id}", Name="GetCarById")]
        public ActionResult <CarReadDto> GetCarById(int id)
        {
            var carItem = _repository.GetCarById(id);
            if(carItem != null)
            {
                return Ok(_mapper.Map<CarReadDto>(carItem));
            }
            return NotFound();
        }

        //api/cars/
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

            var carReadDto = _mapper.Map<CarReadDto>(carModel);

            return CreatedAtRoute(nameof(GetCarById), new {Id = carReadDto.Id}, carReadDto);
        }

        //api/cars/{id}
        [HttpPut("{id}")]
        public ActionResult <CarReadDto> UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(carUpdateDto, carModelFromRepo);

            _repository.UpdateCar(carModelFromRepo);
            _repository.SaveChanges();
            return Ok(_mapper.Map<CarReadDto>(carModelFromRepo));
        }

        //api/cars/{id}
        [HttpPatch("{id}")]
        public ActionResult <CarReadDto> PartialUpdateCar(int id, JsonPatchDocument<CarUpdateDto> patchdoc)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            var carToPatch = _mapper.Map<CarUpdateDto>(carModelFromRepo);
            patchdoc.ApplyTo(carToPatch, ModelState);
            if(!TryValidateModel(carToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(carToPatch, carModelFromRepo);

            switch (carModelFromRepo.Class.ToString())
            {
                case "Luxury":
                    carModelFromRepo.PricePerDay = 100;
                    break;
                case "Medium":
                    carModelFromRepo.PricePerDay = 60;
                    break;
                case "Easy":
                    carModelFromRepo.PricePerDay = 40;
                    break;
                default:
                    return BadRequest();
            }
            _repository.UpdateCar(carModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<CarReadDto>(carModelFromRepo));
        }

        //api/cars/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var carModelFromRepo = _repository.GetCarById(id);
            if(carModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCar(carModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}