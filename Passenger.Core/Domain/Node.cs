using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public string Address { get; protected set; }
        public double Longitude {get; protected set;}
        public double Latitude {get; protected set;}

        protected Node() { } //some libraries requires this constructor to serialize data without any problem ( read data )
        

        public Node(string adress, double longitude, double latitude)
        {
            SetAddress(adress);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public void SetAddress(string address)
        {
            if(!NameRegex.IsMatch(address))
            {
                throw new Exception("Address is invalid.");
            }

            if (Address == address)
            {
                return;
            }

            Address = address;
        }

        public void SetLongitude(double longitude)
        {
            if(longitude > -180 && longitude < 180) 
            {
                throw new Exception("Please provide valid data.");
            }

            if (Longitude == longitude)
            {
                return;
            }

            Longitude = longitude;
        }
        public void SetLatitude(double latitude)
        {
            if(latitude > - 90 && latitude < 90) 
            {
                throw new Exception("Please provide valid data.");
            }

            if (Latitude == latitude)
            {
                return;
            }

            Latitude = latitude;
        }
    }
}