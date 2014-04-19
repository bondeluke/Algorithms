using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PouringWater
{
    class Edge
    {
        public BucketState FromNode { get; set; }
        public BucketState ToNode { get; private set; }
        public int Weight { get; private set; }

        public Edge(BucketState fromNode, BucketState toNode, int weight) 
        {
            FromNode = fromNode; 
            ToNode = toNode;
            Weight = weight;
        }

        public bool Equals(Edge edge)
        {
            return FromNode.Equals(edge.FromNode) && ToNode.Equals(edge.ToNode);
        }

        public override string ToString()
        {
            return String.Format("{0}--{1}->{2}", FromNode, Weight, ToNode);
        }
    }
}
