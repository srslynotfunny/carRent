using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarReadDto>();
        }
    }
}