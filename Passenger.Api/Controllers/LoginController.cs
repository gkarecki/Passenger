using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Accounts;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public LoginController(ICommandDispatcher commandDispatcher, IMemoryCache memoryCache): base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }
 
        public async Task<IActionResult> Post ([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _memoryCache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}