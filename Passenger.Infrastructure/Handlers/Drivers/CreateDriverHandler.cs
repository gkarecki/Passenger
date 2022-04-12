using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;
        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateAsync(command.UserId);
            await _driverService.SetVehicleAsync(command.UserId, command.VehicleBrand, command.VehicleName, command.VehicleSeats);
        }
    }
}