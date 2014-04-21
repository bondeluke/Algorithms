using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class Path
    {
        public List<Edge> Edges { get; private set; }

        public Path(List<Edge> rootEdge)
        {
            Edges = new List<Edge>(rootEdge);
        }

        public int NumEdges { get { return Edges.Count; } }

        public int Weight
        {
            get
            {
                int weight = 0;
                foreach (Edge edge in Edges)
                    weight += edge.Weight;
                return weight;
            }
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public BucketState FrontNode
        {
            get
            {
                return Edges[NumEdges - 1].ToNode;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Edge edge in Edges)
                sb.Append(edge.FromNode.ToString() + " -> ");
            sb.Append(Edges[NumEdges - 1].ToNode.ToString());

            return sb.ToString();
        }
    }
}
