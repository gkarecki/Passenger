using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id {get; protected set;}    //global unique identifier
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}

        public string Username {get; protected set;}

        public string FullName {get; protected set;}
        public string Role {get; protected set;}
        public DateTime CreateAt {get; protected set;}

        protected User()    //niektóre bibloteki wymagają tego konstruktora, aby nie mieć kłopotu z serializacją naszych danych (odczytem)
        {                   //some libraries requires this contructor to serialize data without any problem ( read data )
        }

        public User(Guid userId,string email, string username, string fullName, string password, string salt, string role) 
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetFullName(fullName);
            SetPassword(password);
            Role = role;
            CreateAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Password == password)
            {
                return;
            }

            Password = password;
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email.ToLowerInvariant()))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Email == email)
            {
                return;
            }

            Email = email;
        }

        public void SetUsername(string username)
        {
            if(!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            else if(string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Username == username)
            {
                return;
            }

            Username = username;
        }

        public void SetFullName(string fullName)
        {
            if(string.IsNullOrWhiteSpace(fullName))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (FullName == fullName)
            {
                return;
            }
            FullName = fullName;   

        }
    }
}