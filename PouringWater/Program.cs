using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bucket> buckets = new List<Bucket>();
            buckets.Add(new Bucket(4, 4));
            buckets.Add(new Bucket(7, 7));
            buckets.Add(new Bucket(0, 10));

            Graph graph = new Graph(new BucketState(buckets));
            graph.Populate();
            graph.ShortestPath(graph.Nodes[0], graph.Nodes[3]);
        }
    }
}
