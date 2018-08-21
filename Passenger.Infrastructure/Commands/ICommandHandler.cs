
using System.Threading.Tasks;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Infrastructure.Commands
{
    public interface ICommandHandler <T> where T : ICommand
    {
        Task HandnleAsync(T command);
    }
}