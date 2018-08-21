using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userservice;
        public CreateUserHandler(IUserService userService)
        {
            _userservice = userService;
        }
        public async Task HandnleAsync(CreateUser command)
        {
            await _userservice.RegisterAsync(command.Email, command.Username, command.FullName, command.Password);
        }
    }
}