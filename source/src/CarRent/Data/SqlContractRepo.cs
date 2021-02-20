using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;

namespace CarRent.Data
{
    public class SqlContractRepo : IContractRepo
    {
        private readonly CarRentContext _context;

        public SqlContractRepo(CarRentContext context)
        {
            _context = context;
        }
        public void CreateContract(Contract contract)
        {
            if(contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }
            _context.Contracts.Add(contract);
        }

        public void DeleteContract(Contract contract)
        {
            if(contract == null)
            {
                throw new ArgumentNullException(nameof(contract));
            }

            _context.Contracts.Remove(contract);
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            return _context.Contracts.ToList();
        }

        public Contract GetContractById(int id)
        {
            return _context.Contracts.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateContract(Contract contract)
        {
            //do nothing
        }
    }
}