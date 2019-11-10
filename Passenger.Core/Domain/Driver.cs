using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        // public Guid Id { get; protected set; } //now not necessary
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes {get; protected set;}
        public IEnumerable<DailyRoute> DailyRoutes {get; protected set;}
        public DateTime UpdatedAt {get; private set;}

        protected Driver()
        {}
        public Driver(User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }
        public Driver(Guid userId,Vehicle vehicle)
        {
            // Id = new Guid();
            SetUserId(userId);
            SetVehicle(vehicle);
        }
        public void SetUserId(Guid userId)
        {
            if(UserId == userId)
            {
                return;
            }
            UserId = userId;
        }

        public void SetVehicle(Vehicle vehicle)
        {
            // Vehicle vehicle = new Vehicle(name, brand, seats); //zastąpiłem metodą Create()
            // Vehicle = vehicle;
            Vehicle = vehicle;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

// To do: konstrukotry protected wszędzie ; konstruktory publiczne, gdzie bedziemy ustatlali identyfikatory ; będziemy pamiętali, ze będzie przekazany użytkowanik, jego pojazd;