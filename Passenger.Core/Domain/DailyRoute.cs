using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes {get ; protected set;}

        protected DailyRoute()
        {
        }
        public DailyRoute(Route route)
        {
            Id = new Guid();
            Route = route;
        }
        // public IEnumerable<PassengerNode> SetPassengerNode()
        // {
        //     yield return;
        // }
           
    }
}