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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICarRepo _carRepo;
        private readonly ICustomerRepo _customerRepo;

        public ReservationsController(IReservationRepo repository, IMapper mapper, ICarRepo carRepo, ICustomerRepo customerRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _carRepo = carRepo;
            _customerRepo = customerRepo;
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
            var days = (reservationModel.EndDate - reservationModel.BeginDate).TotalDays;
            int luxuryCosts = 100;
            int mediumCosts = 60;
            int easyCosts = 40;
            //check if user exists
            if(_customerRepo.GetCustomerById(reservationModel.CustomerId) == null)
            {
                return BadRequest("CustomerId not valid");
            }
            switch (reservationModel.CarClass.ToString().ToLower())
            {
                case "luxury":
                    reservationModel.Costs = (int)days * luxuryCosts;
                    break;
                case "medium":
                    reservationModel.Costs = (int)days * mediumCosts;
                    break;
                case "easy":
                    reservationModel.Costs = (int)days * easyCosts;
                    break;
                default:
                    return BadRequest("CarClass not valid");
            }

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

        //api/reservations/{id}
        [HttpPatch("{id}")]
        public ActionResult <ReservationReadDto> PartialUpdateReservation(int id, JsonPatchDocument<ReservationUpdateDto> patchDoc)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if(reservationModelFromRepo == null)
            {
                return NotFound();
            }

            var reservationToPatch = _mapper.Map<ReservationUpdateDto>(reservationModelFromRepo);
            patchDoc.ApplyTo(reservationToPatch, ModelState);
            if(!TryValidateModel(reservationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(reservationToPatch, reservationModelFromRepo);

            _repository.UpdateReservation(reservationModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<ReservationReadDto>(reservationModelFromRepo));
        }

        //api/reservations/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if(reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteReservation(reservationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}