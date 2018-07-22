using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        // public Guid Id { get; protected set; } //now not necessary
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes {get; protected set;}
        public IEnumerable<DailyRoute> DailyRoutes {get; protected set;}

        protected Driver()
        {}

        public Driver(Guid userId, string name, string brand, int seats)
        {
            // Id = new Guid();
            SetUserId(userId);
            SetVehicle(name , brand, seats);
        }
        public void SetUserId(Guid userId)
        {
            if(UserId == userId)
            {
                return;
            }
            UserId = userId;
        }

        public void SetVehicle(string name, string brand, int seats)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (seats > 0 && seats <=5)
            {
                throw new Exception("Please provide valid data.");                
            }
            else if(Vehicle.Name == name || Vehicle.Brand == brand || Vehicle.Seats == seats)
            {
                return;
            }

            // Vehicle vehicle = new Vehicle(name, brand, seats); //zastąpiłem metodą Create()
            // Vehicle = vehicle;
            Vehicle = Vehicle.Create(name, brand, seats);
        }
    }
}

// To do: konstrukotry protected wszędzie ; konstruktory publiczne, gdzie bedziemy ustatlali identyfikatory ; będziemy pamiętali, ze będzie przekazany użytkowanik, jego pojazd;