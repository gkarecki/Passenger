namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        public Node Node {  get; protected set; }
        public Passenger Passenger { get; protected set;}

        protected PassengerNode()
        {}

        public PassengerNode(Node node, Passenger passenger)
        {
            SetNode(Node);
            SetPassenger(passenger);
        }
        public void SetNode(Node node)
        {
            if (Node == node)
            {
                return;
            }

            Node = node;
        }
        public void SetPassenger(Passenger passenger)
        {
            if (Passenger == passenger)
            {
                return;
            }

            Passenger = passenger;
        }

    }
}