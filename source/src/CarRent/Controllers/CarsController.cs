using System.Collections.Generic;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _repository;

        public CarsController(ICarRepo repository)
        {
            _repository = repository;
        }
        
        //private readonly MockCarRepo _repository = new MockCarRepo();

        //api/cars
        [HttpGet]
        public ActionResult <IEnumerable<Car>> GetAllCars()
        {
            var carItems = _repository.GetAllCars();
            return Ok(carItems);
        }

        //api/cars/5
        [HttpGet("{id}")]
        public ActionResult <int> GetCarById(int id)
        {
            var carItem = _repository.GetCarById(id);
            if(carItem != null)
            {
                return Ok(carItem);
            }
            return NotFound();
        }
    }
}