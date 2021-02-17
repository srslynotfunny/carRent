using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            //Source -> Target
            CreateMap<Car, CarReadDto>();
            
            CreateMap<CarCreateDto, Car>();

            CreateMap<CarUpdateDto, Car>();
        }
    }
}