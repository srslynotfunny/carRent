using System;
using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Data
{
    public class MockReservationRepo : IReservationRepo
    {
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
            var reservations = new List<Reservation>
            {
                new Reservation{Id=1, CustomerId=1, CarClass="Luxury", BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=300},
                new Reservation{Id=2, CustomerId=2, CarClass="Medium", BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=300},
                new Reservation{Id=3, CustomerId=3, CarClass="Easy", BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=300}
            };

            return reservations;
        }

        public Reservation GetReservationById(int id)
        {
            return new Reservation{Id=1, CustomerId=1, CarClass="Luxury", BeginDate=new DateTime(2021, 3, 12), EndDate=new DateTime(2021, 3, 15), Costs=300};
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