using System;
using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public class MockContractRepo : IContractRepo
    {
        public void CreateContract(Contract contract)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContract(Contract contract)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            var contracts = new List<Contract> {
            new Contract{Id=1, CustomerId=1, Name="Riklef Irps", Street="Lindenstrasse 102",
                City="Widnau", Postalcode="9443", CarId=1, Manufacturer="BMW", Model="M2", Class="Luxury", PricePerDay=100,
                ReservationId=1, BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=500},
            new Contract{Id=2, CustomerId=1, Name="Riklef Irps", Street="Lindenstrasse 102",
                City="Widnau", Postalcode="9443", CarId=1, Manufacturer="BMW", Model="M2", Class="Luxury", PricePerDay=100,
                ReservationId=1, BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=500},
            new Contract{Id=3, CustomerId=1, Name="Riklef Irps", Street="Lindenstrasse 102",
                City="Widnau", Postalcode="9443", CarId=1, Manufacturer="BMW", Model="M2", Class="Luxury", PricePerDay=100,
                ReservationId=1, BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=500}
            };
            return contracts;
        }

        public Contract GetContractById(int id)
        {
            return new Contract{Id=1, CustomerId=1, Name="Riklef Irps", Street="Lindenstrasse 102",
                City="Widnau", Postalcode="9443", CarId=1, Manufacturer="BMW", Model="M2", Class="Luxury", PricePerDay=100,
                ReservationId=1, BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=500};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContract(Contract contract)
        {
            throw new System.NotImplementedException();
        }
    }
}