using System;

namespace Passenger.Infrastructure.Commands.Users
{
    public class CreateUser : ICommand
    {
        // public Guid userId {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Username {get; set;}
        public string Role {get; set;}
        //public string FullName {get; set;}
    }
}