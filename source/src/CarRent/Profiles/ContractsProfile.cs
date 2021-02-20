using AutoMapper;
using CarRent.Dtos;
using CarRent.Models;

namespace CarRent.Profiles
{
    public class ContractsProfile : Profile
    {
        public ContractsProfile()
        {
            CreateMap<Contract, ContractReadDto>();
            CreateMap<ContractCreateDto, Contract>();
            CreateMap<ContractUpdateDto, Contract>();
            CreateMap<Contract, ContractUpdateDto>();
        }
    }
}