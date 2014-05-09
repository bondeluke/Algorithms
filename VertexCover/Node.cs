using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAllCycles
{
    class Node
    {
        public int ID { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Node(int nodeID)
        {
            ID = nodeID;
            Edges = new List<Edge>();
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
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
