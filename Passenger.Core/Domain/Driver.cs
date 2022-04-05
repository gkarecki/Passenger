using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes {get; protected set;}
        public IEnumerable<DailyRoute> DailyRoutes {get; protected set;}
        public DateTime UpdatedAt {get; private set;}

        protected Driver() { } //some libraries requires this constructor to serialize data without any problem ( read data )

        public Driver(User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }

        public Driver(Guid userId, string name, string brand, int seats)
        {
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
            Vehicle = Vehicle.Create(name, brand, seats);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}