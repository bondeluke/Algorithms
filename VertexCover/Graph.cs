using System;
using System.Collections;
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
                fromNode.AddEdge(edge);
                toNode.AddEdge(edge);
            }
            graphStream.Close();
        }

        private Node GetNode(int nodeID)
        {
            foreach (Node node in Nodes)
                if (node.ID == nodeID)
                    return node;

            return null;
        }

        private bool CoversGraph(ICollection<Node> nodes)
        {
            bool[] IsCovered = new bool[NumEdges];
            for (int i = 0; i < NumEdges; i++)
                IsCovered[i] = false;

            foreach (Node node in nodes)
                foreach (Edge edge in node.Edges)
                    IsCovered[edge.ID] = true;

            foreach (bool isCovered in IsCovered)
                if (isCovered == false)
                    return false;

            return true;
        }

        public List<Node> FindVertexCover(int budget)
        {
            foreach (var subset in AllSubsetsOfSize(budget))
                if (CoversGraph(subset))
                    return subset;

            return null;
        }

        private List<List<Node>> AllSubsetsOfSize(int size)
        {
            List<List<Node>> allSubsets = new List<List<Node>>();

            Queue<List<Node>> Q = new Queue<List<Node>>();

            foreach (Node node in Nodes)
            {
                List<Node> root = new List<Node>();
                root.Add(node);
                Q.Enqueue(root);
            }

            while (Q.Count != 0)
            {
                List<Node> subset = Q.Dequeue();
                if (subset.Count == size)
                {
                    allSubsets.Add(subset);
                }
                else
                {
                    foreach (Node node in Nodes)
                        if (node.ID > subset[subset.Count - 1].ID)
                        {
                            List<Node> newSubset = new List<Node>(subset);
                            newSubset.Add(node);
                            Q.Enqueue(newSubset);
                        }
                }
            }

            return allSubsets;
        }
    }
}
