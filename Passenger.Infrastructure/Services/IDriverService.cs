using System;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
        DriverDTO Get(Guid userId);

        void AddAsDriver(Guid UserId, Vehicle vehicle);
    }
}