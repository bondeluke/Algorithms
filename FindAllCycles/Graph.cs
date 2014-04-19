using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllCycles
{
    class Graph
    {
        public List<Node> Nodes { get; private set; }
        public List<Edge> Edges { get; private set; }
        public int NumNodes { get; private set; }
        public int NumEdges { get; private set; }

        public Graph(StreamReader graphStream)
        {
            var line1 = graphStream.ReadLine().Split();
            NumNodes = Convert.ToInt32(line1[2]);
            NumEdges = Convert.ToInt32(line1[3]);

            Nodes = new List<Node>();
            for (int id = 0; id < NumNodes; id++)
                Nodes.Add(new Node(id));

            Edges = new List<Edge>();
            for (int id = 0; id < NumEdges; id++)
            {
                var line = graphStream.ReadLine().Split();
                Node fromNode = GetNode(Convert.ToInt32(line[0]));
                Node toNode = GetNode(Convert.ToInt32(line[1]));
                Edge edge = new Edge(id, fromNode, toNode);
                Edges.Add(edge);
                fromNode.AddOutGoingEdge(edge);
            }
            graphStream.Close();
        }

        public List<Cycle> FindAllCycles()
        {
            List<Cycle> cycles = new List<Cycle>();
            Queue<Path> Q = new Queue<Path>();

            Node root = GetNode(0);
            foreach (Edge edge in root.OutgoingEdges)
                Q.Enqueue(new Path(edge));

            Path currentPath, newPath;
            while (Q.Count != 0)
            {
                currentPath = Q.Dequeue();
                foreach (Edge edge in currentPath.FrontNode.OutgoingEdges)
                {
                    if (!currentPath.Contains(edge) && currentPath.Length < NumNodes)
                    {
                        newPath = new Path(currentPath);
                        newPath.AddEdge(edge);
                        if (newPath.ContainsCycle())
                        {
                            bool cycleIsNew = true;
                            Cycle newCycle = newPath.ToCycle();

                            foreach (Cycle cycle in cycles)
                                if (cycle.Equals(newCycle))
                                    cycleIsNew = false;

                            if (cycleIsNew)
                                cycles.Add(newCycle);
                        }
                        else
                        {
                            Q.Enqueue(newPath);
                        }
                    }
                }
            }
            cycles = cycles.OrderBy(cycle => cycle.Length).ToList();
            return cycles;
        }

        private Node GetNode(int nodeID)
        {
            foreach (Node node in Nodes)
                if (node.ID == nodeID)
                    return node;

            return null;
        }
    }
}
