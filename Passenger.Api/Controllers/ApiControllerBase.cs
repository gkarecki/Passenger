using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
 
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            this.CommandDispatcher = commandDispatcher;
        }
    }
}