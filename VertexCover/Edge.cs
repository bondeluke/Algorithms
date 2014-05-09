using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAllCycles
{
    class Edge
    {
        public int ID { get; private set; }
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }

        public Edge(int edgeID, Node fromNode, Node toNode)
        {
            ID = edgeID;
            FromNode = fromNode;
            ToNode = toNode;
        }

        public override string ToString()
        {
            return "ID " + ID + " from " + FromNode.ID + " to " + ToNode.ID; 
        }

        public bool Equals(Edge edge)
        {
            return ID == edge.ID;
        }
    }
}
