using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    
    public class UsersController : Controller
    {
        private readonly IUserService _userservice;
        public UsersController(IUserService userService)
        {
            _userservice = userService;
        }
        // GET api/values/5
        [HttpGet("{email}")]
        public UserDTO Get(string email)
                        => _userservice.Get(email);

        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userservice.Register(request.Email, request.Username, request.FullName, request.Password);
        }
    }
}


