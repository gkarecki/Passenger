using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userservice;
        private readonly GeneralSettings _settigns;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, GeneralSettings settings) : base(commandDispatcher)
        {
            _settigns = settings;
            _userservice = userService;
        }

        // [Authorize(Policy = "admin")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            var user = await _userservice.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }

    }
}


