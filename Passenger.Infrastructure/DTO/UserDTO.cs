using System;

namespace Passenger.Infrastructure.DTO
{
    public class UserDTO
    {
        public Guid Id {get; set;}    //global unique identifier
        public string Email {get; set;}

        public string Username {get; set;}

        public string Role {get; set;}

    }
}