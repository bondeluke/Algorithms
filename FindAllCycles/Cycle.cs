using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAllCycles
{
    class Cycle
    {
        public List<Edge> Edges { get; private set; }
        public int Length { get { return Edges.Count; } }

        public Cycle(List<Edge> edges)
        {
            Edges = new List<Edge>(edges);
        }

        public List<Edge> OrderedEdges
        {
            get
            {
                return Edges.OrderBy(edge => edge.ID).ToList();
            }
        }

        public bool Equals(Cycle cycle)
        {
            if (Length != cycle.Length)
                return false;

            for (int i = 0; i < Length; i++)
                if (!OrderedEdges[i].Equals(cycle.OrderedEdges[i]))
                    return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Edge edge in Edges)
                sb.Append(edge.FromNode.ID + " -> ");
            sb.Append(Edges[Length - 1].ToNode.ID);

            return sb.ToString();
        }
    }
}
