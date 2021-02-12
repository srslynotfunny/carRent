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
        private readonly MockCarRepo _repository = new MockCarRepo();

        //GET api/cars
        [HttpGet]
        public ActionResult <IEnumerable<Car>> GetAllCars()     //Name spielt hier keine Rolle, Benennung macht Sinn
        {
            var carItems = _repository.GetAllCars();
            return Ok(carItems);
        }

        //GET api/cars/{id}
        [HttpGet("{id}", Name="GetCarById")]
        public ActionResult <Car> GetCarById(int id)
        {
            var carItem = _repository.GetCarById(id);
            return Ok(carItem);
        }
    }
}