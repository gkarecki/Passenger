using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {

        private static ISet<User> _users = new HashSet<User>();
        // {
        //     new User("user1@email.com","user1","fullName", "secret", "salt"),
        //     new User("user2@email.com","user2","fullName", "secret", "salt"),
        //     new User("user3@email.com","user3","fullName", "secret", "salt")
        // };
        

        public async Task<User> GetAsync(Guid id)
                    => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
                    => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));
        public async Task<IEnumerable<User>> BrowseAsync()
                => await Task.FromResult(_users);
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }
        
        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;

        }

        public async Task UpdateAsync(User user)
        {
            //narazie nic nie potrzebujemy, bo nie mamy bazy danych.
            await Task.CompletedTask;
        }
    }
}
