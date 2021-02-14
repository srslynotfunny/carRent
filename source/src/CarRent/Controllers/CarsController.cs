using System.Collections.Generic;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    //can also use api/cars --> same result
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
        public ActionResult <IEnumerable<Car>> GetAllCars()     //Name spielt hier keine Rolle, Benennung macht Sinn
        {
            var carItems = _repository.GetAllCars();
            return Ok(carItems);
        }

        //api/cars/id?5
        [HttpGet("id")]
        public ActionResult <Car> GetCarById([FromQuery]int id)
        {
            var carItem = _repository.GetCarById(id);
            return Ok(carItem);
        }
    }
}