using System;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public string Address { get; protected set; }
        public double Longitude {get; protected set;}
        public double Latitude {get; protected set;}

        protected Node()
        {
        }
        public Node(string adress, double longitude, double latitude)
        {
            SetAddress(adress);
            SetLongitudeLatitude(longitude, latitude);
        }
        public void SetAddress(string adress)
        {
            if(string.IsNullOrWhiteSpace(adress))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Address == adress)
            {
                return;
            }

            Address = adress;
        }
        public void SetLongitudeLatitude(double longitude, double latitude)
        {
            if(double.IsNaN(longitude) && double.IsNaN(latitude))
            {
                throw new Exception("Please provide valid data.");
            }
            else if (Longitude == longitude && Latitude == latitude)
            {
                return;
            }

            Longitude = longitude;
            Latitude = latitude;
        }
    }
}