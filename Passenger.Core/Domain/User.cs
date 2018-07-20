using System;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid Id {get; protected set;}    //global unique identifier
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}

        public string Username {get; protected set;}

        public string FullName {get; protected set;}
        public DateTime CreateAt {get; protected set;}

        protected User() //niektóre bibloteki wymagają tego konstruktora, aby nie mieć kłopotu z serializacją naszych danych (odczytem)
        {
        }

        public User(string email, string username, string password, string salt) // konieczna walidacja (wyrażenia regularne czyli regex)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant(); //musi być unikalny
            Username = username; //czy username pusty, czy nie zawiera niedozwolonych znaków 
            Password = password; //czy nie puste
            Salt = salt;
            CreateAt = DateTime.UtcNow;
        }
    }
}