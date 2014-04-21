using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class Graph
    {
        public List<BucketState> Nodes { get; private set; }
        public List<Edge> Edges { get; private set; }
        public int NumBuckets;
        private const int INFTY = Int32.MaxValue;

        public Graph(BucketState initialState)
        {
            Nodes = new List<BucketState>();
            Edges = new List<Edge>();

            NumBuckets = initialState.Degree;
            Nodes.Add(initialState);
        }

        public void Populate()
        {
            Queue<BucketState> Q = new Queue<BucketState>();
            Q.Enqueue(Nodes[0]);

            while (Q.Count != 0)
            {
                var currentState = Q.Dequeue();
                for (int fromID = 0; fromID < NumBuckets; fromID++)
                    for (int toID = 0; toID < NumBuckets; toID++)
                        if (fromID != toID)
                            if (Bucket.CanPour(currentState.Buckets[fromID], currentState.Buckets[toID]))
                            {
                                Bucket fromClone = currentState.Buckets[fromID].Clone();
                                Bucket toClone = currentState.Buckets[toID].Clone();
                                int weight = Bucket.Pour(fromClone, toClone);
                                List<Bucket> buckets = new List<Bucket>(currentState.Buckets);
                                buckets.RemoveAt(fromID);
                                buckets.Insert(fromID, fromClone);
                                buckets.RemoveAt(toID);
                                buckets.Insert(toID, toClone);
                                BucketState stateCandidate = new BucketState(buckets);
                                bool stateCandidateExists = GetCandidateReference(ref stateCandidate);
                                if (!stateCandidateExists)
                                {
                                    Nodes.Add(stateCandidate);
                                    Q.Enqueue(stateCandidate);
                                }
                                Edge edgeCandidate = new Edge(currentState, stateCandidate, weight);
                                if (!EdgesExists(edgeCandidate))
                                    Edges.Add(edgeCandidate);
                            }
            }
            foreach (BucketState node in Nodes)
                foreach (Edge edge in Edges)
                    if (node.Equals(edge.FromNode))
                        node.AddOutgoingEdge(edge);
        }

        public Path SolveProblem()
        {
            BucketState from = Nodes[0];
            Dictionary<BucketState, int> distance = new Dictionary<BucketState, int>(Nodes.Count);
            for (int i = 0; i < Nodes.Count; i++)
                distance[Nodes[i]] = INFTY;

            Dictionary<BucketState, BucketState> prev = new Dictionary<BucketState, BucketState>();
            prev[from] = null;

            distance[from] = 0;
            PriorityQueue<BucketState> Q = new PriorityQueue<BucketState>();
            Q.Push(from, distance[from]);
            while (Q.Count != 0)
            {
                BucketState current = Q.Pop();
                foreach (Edge edge in current.OutgoingEdges)
                    if (edge.Weight + distance[current] < distance[edge.ToNode])
                    {
                        distance[edge.ToNode] = edge.Weight + distance[current];
                        Q.Push(edge.ToNode, distance[edge.ToNode]);
                        prev[edge.ToNode] = current;
                    }
            }

            int minDistance = INFTY;
            BucketState closestState = null;
            foreach (var item in distance)
                if (item.Key.Buckets[0].Amount == 2 || item.Key.Buckets[1].Amount == 2)
                    if (item.Value < minDistance)
                    {
                        minDistance = item.Value;
                        closestState = item.Key;
                    }
            List<Edge> pathEdges = new List<Edge>();
            BucketState currentNode = closestState;
            while (currentNode != Nodes[0])
            {
                pathEdges.Add(GetEdge(prev[currentNode], currentNode));
                currentNode = prev[currentNode];
            }
            pathEdges.Reverse();

            return new Path(pathEdges);
        }

        #region Private Methods
        private bool GetCandidateReference(ref BucketState candidate)
        {
            foreach (var node in Nodes)
                if (node.Equals(candidate))
                {
                    candidate = node;
                    return true;
                }

            return false;
        }

        private bool EdgesExists(Edge candidate)
        {
            foreach (Edge edge in Edges)
                if (edge.Equals(candidate))
                    return true;

            return false;
        }

        private Edge GetEdge(BucketState from, BucketState to)
        {
            foreach (Edge edge in Edges)
                if (edge.FromNode == from && edge.ToNode == to)
                    return edge;
            return null;
        }
        #endregion
    }
}