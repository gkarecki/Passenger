using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands.Users
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}