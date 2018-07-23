using System;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
        Task<DriverDTO> GetAsync(Guid userId);

        Task AddAsDriverAsync(Guid UserId, Vehicle vehicle);
    }
}