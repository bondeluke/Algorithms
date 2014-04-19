using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class PriorityQueue<T>
    {
        private List<ItemKey<T>> Q;

        public PriorityQueue()
        {
            Q = new List<ItemKey<T>>();
        }

        public int Count { get { return Q.Count; } }

        public void Push(T item, int key)
        {
            Q.Add(new ItemKey<T>(item, key));
            Order();
        }

        public T Pop()
        {
            T item = Q[0].Item;
            Q.RemoveAt(0);
            return item;
        }

        private void Order()
        {
            Q.OrderBy(item => item.Key);
        }
    }
}
