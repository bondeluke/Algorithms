using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PouringWater
{
    class Bucket
    {
        public int Amount { get; private set; }
        public int Capacity { get; private set; }

        public Bucket(int amount, int capacity)
        {
            Amount = amount;
            Capacity = capacity;
        }

        public int Space { get { return Capacity - Amount; } }

        public int Fill() { int diff = Space; Amount = Capacity; return diff; }

        public int Empty() { int returnAmount = Amount; Amount = 0; return returnAmount; }

        public Bucket Clone()
        {
            return new Bucket(Amount, Capacity);
        }

        public bool Equals(Bucket b)
        {
            return (Amount == b.Amount && Capacity == b.Capacity);
        }

        public static int Pour(Bucket from, Bucket to)
        {
            int initialFromAmount = from.Amount;
            if (from.Amount <= to.Space)
                to.Amount += from.Empty();
            else
                from.Amount -= to.Fill();

            return initialFromAmount - from.Amount;
        }

        public static bool CanPour(Bucket from, Bucket to)
        {
            return (from.Amount != 0 && to.Space != 0);
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Amount, Capacity);
        }
    }
}
