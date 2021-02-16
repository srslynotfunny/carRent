using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
        }
    }
}