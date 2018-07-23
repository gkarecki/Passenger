using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverDTO> GetAsync(Guid id)
        {
            var driver = await _driverRepository.GetAsync(id);
            return  _mapper.Map<Driver, DriverDTO>(driver);
        }
        public async Task AddAsDriverAsync(Guid id, Vehicle vehicle)
        {
            var driver = await _driverRepository.GetAsync(id);
            if (driver != null)
            {
                throw new Exception($"User with id: '{id} already exists.");
            }
            driver = new Driver(id,vehicle.Name, vehicle.Brand, vehicle.Seats); 
            await _driverRepository.AddAsync(driver);
        }
    }
}