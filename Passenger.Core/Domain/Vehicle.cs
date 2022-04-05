using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public int Seats { get; protected set; }
        
        protected Vehicle() { } //some libraries requires this constructor to serialize data without any problem ( read data )

        protected Vehicle(string name, string brand, int seats)
        {
            SetName(name);
            SetBrand(brand);
            SetSeats(seats);
        }

        private void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }
        private void SetBrand(string brand)
        {
            if(string.IsNullOrWhiteSpace(brand))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }

            if (Brand == brand)
            {
                return;
            }

            Brand = brand;
        }
        private void SetSeats(int seats)
        {
            if (Seats == seats)
            {
                return;
            }

            Seats = seats;
        }
        public static Vehicle Create(string name, string brand, int seats) => new Vehicle(brand, name, seats);
    }
}