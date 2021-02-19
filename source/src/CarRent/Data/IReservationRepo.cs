using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public interface IReservationRepo
    {
        bool SaveChanges();
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
    }
}