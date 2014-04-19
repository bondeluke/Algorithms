using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllCycles
{
    class Path
    {
        public List<Edge> Edges { get; private set; }
        public int Length { get { return Edges.Count; } }

        public Path(Edge rootEdge)
        {
            Edges = new List<Edge>();
            Edges.Add(rootEdge);
        }

        public Path(Path path)
        {
            Edges = new List<Edge>();

            foreach (Edge edge in path.Edges)
                Edges.Add(edge);
        }

        public bool Contains(Edge edge)
        {
            foreach (Edge localEdge in Edges)
                if (localEdge.Equals(edge))
                    return true;
            return false;
        }

        public bool ContainsCycle()
        {
            for (int i = 0; i < Edges.Count; i++)
                if (Edges[i].FromNode.Equals(FrontNode))
                    return true;

            return false;
        }

        public Cycle ToCycle()
        {
            int rootIndex = -1;
            for (int i = 0; i < Edges.Count; i++)
                if (Edges[i].FromNode.Equals(FrontNode))
                    rootIndex = i;

            List<Edge> cycleEdges = new List<Edge>(Edges);

            cycleEdges.RemoveRange(0, rootIndex);

            Cycle cycle = new Cycle(cycleEdges);

            return cycle;
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public Node FrontNode
        {
            get
            {
                return Edges[Length - 1].ToNode;
            }
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
