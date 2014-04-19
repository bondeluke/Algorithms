using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAllCycles
{
    class Node
    {
        public int ID { get; private set; }
        public List<Edge> OutgoingEdges { get; private set; }

        public Node(int nodeID)
        {
            ID = nodeID;
            OutgoingEdges = new List<Edge>();
        }

        public void AddOutGoingEdge(Edge edge)
        {
            OutgoingEdges.Add(edge);
        }

        public bool Equals(Node node)
        {
            return ID == node.ID;
        }

        public override string ToString()
        {
            return "ID " + ID;
        }
    }
}
