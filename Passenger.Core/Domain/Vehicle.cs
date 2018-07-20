using System;

namespace Passenger.Core.Domain
{
    public class Vehicle    // ValueObject tzn. Immutable (niezmienialny) 
    {
        public string Name { get; protected set; }
        public string Brand { get; protected set; }
        public int Seats { get; protected set; }
        
        protected Vehicle()
        {}

        public Vehicle(string name, string brand, int seats)
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
            else if (Name == name)
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
            else if (Brand == brand)
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
    }
}