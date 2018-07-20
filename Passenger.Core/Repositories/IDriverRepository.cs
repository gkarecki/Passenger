using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAll();
        Driver Get(Guid userId);
        void Add(Driver driver);
        void Update(Driver driver);
        // void Remove(Guid  id);
        
    }
}