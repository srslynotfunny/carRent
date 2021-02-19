using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<Reservation, ReservationReadDto>();
            CreateMap<ReservationCreateDto, Reservation>();
        }
    }
}