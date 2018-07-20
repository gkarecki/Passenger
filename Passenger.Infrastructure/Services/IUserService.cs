using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService
    {
        UserDTO Get(string email);
        void Register(string email, string username, string fullName, string password);
    }
}