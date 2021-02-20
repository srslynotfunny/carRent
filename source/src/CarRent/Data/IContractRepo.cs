using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public interface IContractRepo
    {
        bool SaveChanges();
        IEnumerable<Contract> GetAllContracts();
        Contract GetContractById(int id);
        void CreateContract(Contract contract);
        void UpdateContract(Contract contract);
        void DeleteContract(Contract contract);
    }
}