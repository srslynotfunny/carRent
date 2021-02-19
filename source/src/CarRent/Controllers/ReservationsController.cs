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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _repository;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockReservationRepo _repository = new MockReservationRepo();

        //api/reservations/
        [HttpGet]
        public ActionResult <IEnumerable<ReservationReadDto>> GetAllReservations()
        {
            var reservationItems = _repository.GetAllReservations();
            return Ok(_mapper.Map<IEnumerable<ReservationReadDto>>(reservationItems));
        }

        //api/reservations/{id}
        [HttpGet("{id}", Name="GetReservationById")]
        public ActionResult <ReservationReadDto> GetReservationById(int id)
        {
            var reservationItem = _repository.GetReservationById(id);
            return Ok(_mapper.Map<ReservationReadDto>(reservationItem));
        }

        //api/reservations
        [HttpPost]
        public ActionResult <ReservationReadDto> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            var reservationModel = _mapper.Map<Reservation>(reservationCreateDto);

            _repository.CreateReservation(reservationModel);
            _repository.SaveChanges();

            var reservationReadDto = _mapper.Map<ReservationReadDto>(reservationModel);

            return CreatedAtRoute(nameof(GetReservationById), new {Id = reservationReadDto.Id}, reservationReadDto);
        }

        //api/reservations/{id}
        [HttpPut("{id}")]
        public ActionResult <ReservationReadDto> UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if(reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationUpdateDto, reservationModelFromRepo);

            _repository.UpdateReservation(reservationModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<ReservationReadDto>(reservationModelFromRepo));
        }
    }
}