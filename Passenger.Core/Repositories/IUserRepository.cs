using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        //wzorzec, który tworzy abstrakcje nad tym gdzie składujemy nasze dane 
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid  id);
    }
}