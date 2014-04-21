using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class ItemKey<T>
    {
        public T Item { get; private set; }
        public int Key { get; private set; }

        public ItemKey(T item, int key)
        {
            Item = item;
            Key = key;
        }

        public override string ToString()
        {
            return "Item " + Item.ToString() + " Key: " + Key;
        }
    }
}
