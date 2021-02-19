using System.Collections.Generic;
using CarRent.Data;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _repository;
        public ReservationsController(IReservationRepo repository)
        {
            _repository = repository;
        }
        //private readonly MockReservationRepo _repository = new MockReservationRepo();

        //api/reservations/
        [HttpGet]
        public ActionResult <IEnumerable<Reservation>> GetAllReservations()
        {
            var reservationItems = _repository.GetAllReservations();
            return Ok(reservationItems);
        }

        //api/reservations/{id}
        [HttpGet("{id}")]
        public ActionResult <Reservation> GetReservationById(int id)
        {
            var reservationItem = _repository.GetReservationById(id);
            return Ok(reservationItem);
        }
    }
}