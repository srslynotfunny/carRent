using System.Collections.Generic;
using AutoMapper;
using CarRent.Data;
using CarRent.Dtos;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractRepo _repository;
        private readonly IMapper _mapper;

        public ContractsController(IContractRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockContractRepo _repository = new MockContractRepo();

        //api/contracts/
        [HttpGet]
        public ActionResult <IEnumerable<ContractReadDto>> GetAllContracts()
        {
            var contractItems = _repository.GetAllContracts();
            return Ok(_mapper.Map<IEnumerable<ContractReadDto>>(contractItems));
        }

        //api/contracts/{id}
        [HttpGet("{id}", Name="GetContractById")]
        public ActionResult <ContractReadDto> GetContractById(int id)
        {
            var contractItem = _repository.GetContractById(id);
            if(contractItem != null)
            {
                return Ok(_mapper.Map<ContractReadDto>(contractItem));
            }
            return NotFound();
        }

        //api/contracts/
        [HttpPost]
        public ActionResult <ContractReadDto> CreateContract(ContractCreateDto contractCreateDto)
        {
            var contractModel = _mapper.Map<Contract>(contractCreateDto);
            //additional checks etc

            _repository.CreateContract(contractModel);
            _repository.SaveChanges();

            var contractReadDto = _mapper.Map<ContractReadDto>(contractModel);

            return CreatedAtRoute(nameof(GetContractById), new {Id= contractReadDto.Id}, contractReadDto);
        }

        //api/contracts/{id}
        [HttpPatch("{id}")]
        public ActionResult <ContractReadDto> PartialUpdateContract(int id, JsonPatchDocument<ContractUpdateDto> patchdoc)
        {
            var contractModelFromRepo = _repository.GetContractById(id);
            if(contractModelFromRepo == null)
            {
                return NotFound();
            }

            var contractToPatch = _mapper.Map<ContractUpdateDto>(contractModelFromRepo);
            patchdoc.ApplyTo(contractToPatch, ModelState);
            if(!TryValidateModel(contractToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(contractToPatch, contractModelFromRepo);

            _repository.UpdateContract(contractModelFromRepo);
            _repository.SaveChanges();

            return Ok(_mapper.Map<ContractReadDto>(contractModelFromRepo));
        }

        //api/contracts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContract(int id)
        {
            var contractModelFromRepo = _repository.GetContractById(id);
            if(contractModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteContract(contractModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}