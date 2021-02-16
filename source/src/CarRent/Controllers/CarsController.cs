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
    }
}