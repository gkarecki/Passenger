using System;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDTO Get(Guid id)
        {
            var driver = _driverRepository.Get(id);
            return new DriverDTO
            {
                UserId = driver.UserId,
                
                Vehicle = driver.Vehicle
            };
        }
        public void AddAsDriver(Guid id, Vehicle vehicle)
        {
            var driver = _driverRepository.Get(id);
            if (driver != null)
            {
                throw new Exception($"User with id: '{id} already exists.");
            }
            driver = new Driver(id,vehicle.Name, vehicle.Brand, vehicle.Seats); 
            _driverRepository.Add(driver);
        }
    }
}