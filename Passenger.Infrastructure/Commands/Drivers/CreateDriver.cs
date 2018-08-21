using System;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : ICommand
    {
        public Guid UserId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleBrand { get; set; }
        public int VehicleSeats { get; set; }
    }
}