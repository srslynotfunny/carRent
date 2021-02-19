using System.Collections.Generic;
using System.Linq;
using CarRent.Models;

namespace CarRent.Data
{
    public class SqlReservationRepo : IReservationRepo
    {
        private readonly CarRentContext _context;

        public SqlReservationRepo(CarRentContext context)
        {
            _context = context;
        }
        public void CreateReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public Reservation GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }
    }
}