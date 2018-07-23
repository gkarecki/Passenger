using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllAsync();
        Task<Driver> GetAsync(Guid userId);
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        // void Remove(Guid  id);
        
    }
}