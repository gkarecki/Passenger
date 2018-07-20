using System;

namespace Passenger.Core.Domain
{
    public class Route
    {
        public Guid Id { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node StopNode { get; protected set; }

        protected Route()
        {}
        public Route(Node startNode, Node stopNode)
        {
            Id = new Guid();
            SetStartNode(startNode);
            SetStopNode(stopNode);
        }   
        public void SetStartNode(Node startNode)
        {
            if (StartNode == startNode)
            {
                return;
            }

            StartNode = startNode;
        }
        public void SetStopNode(Node stopNode)
        {
            if (StopNode == stopNode)
            {
                return;
            }

            StopNode = stopNode;
        }
    }
}