using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountsController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("user1@email.com", "admin");
            return Json(token);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}