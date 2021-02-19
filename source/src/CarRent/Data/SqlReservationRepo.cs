using System;
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
            if(reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            _context.Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            if(reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }

            _context.Reservations.Remove(reservation);
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
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateReservation(Reservation reservation)
        {
            //do nothing
        }
    }
}