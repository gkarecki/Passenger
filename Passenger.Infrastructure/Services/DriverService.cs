using System;
using System.Collections.Generic;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository,IUserRepository userRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DriverDTO> GetAsync(Guid id)
        {
            var driver = await _driverRepository.GetAsync(id);
            return  _mapper.Map<Driver, DriverDTO>(driver);
        }
        // public async Task AddAsDriverAsync(Guid id, Vehicle vehicle)
        // {
        //     // var driver = await _driverRepository.GetAsync(id);
        //     // if (driver != null)
        //     // {
        //     //     throw new Exception($"User with id: '{id} already exists.");
        //     // }
        //     var driver = new Driver(id,vehicle.Name, vehicle.Brand, vehicle.Seats); 
        //     await _driverRepository.AddAsync(driver);
        // }
        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if(user == null)
            {
                throw new Exception($"User with id: {userId} not found...");
            }
            
            var driver = await _driverRepository.GetAsync(userId);
            if(driver != null)
            {
                throw new Exception($"Driver with id: {userId} already exists...");
            }
            driver = new Driver(user);
            await _driverRepository.AddAsync(driver);
        }
        public async Task SetVehicleAsync(Guid userId, string brand, string name, int seats)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if(driver == null)
            {
                throw new Exception($"Driver with id: {userId} was not found...");
            }
            driver.SetVehicle(name, brand, seats);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task<IEnumerable<DriverDTO>> BrowseAsync()
        {
            var drivers = await _driverRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDTO>>(drivers);
        }
    }
}