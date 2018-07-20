using System;

namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Node Address { get; protected set; }
        protected Passenger()
        {
        }
        public Passenger(Guid userId)
        {
            Id = new Guid();
            SetUserId(userId);
        }
        public void SetUserId(Guid userId)
        {
            if(UserId == userId)
            {
                return;
            }
            UserId = userId;
        }
    }
}