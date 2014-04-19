using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class BucketState
    {
        public List<Bucket> Buckets { get; private set; }
        public List<Edge> OutgoingEdges { get; private set; }

        public BucketState(List<Bucket> buckets)
        {
            Buckets = new List<Bucket>(buckets);
            Buckets = Buckets.OrderBy(bucket => bucket.Capacity).ToList();
            OutgoingEdges = new List<Edge>();
        }

        public int Degree { get { return Buckets.Count; } }

        public void AddOutgoingEdge(Edge edge)
        {
            OutgoingEdges.Add(edge);
        }

        public bool Equals(BucketState bs)
        {
            if (Degree != bs.Degree)
                return false;

            for (int i = 0; i < Degree; i++)
                if (!Buckets[i].Equals(bs.Buckets[i]))
                    return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Degree - 1; i++)
                sb.Append(Buckets[i].ToString() + " ");
            sb.Append(Buckets[Degree - 1].ToString());

            return sb.ToString();
        }
    }
}
