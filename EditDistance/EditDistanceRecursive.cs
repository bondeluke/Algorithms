using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    public class EditDistanceRecursive
    {
        public int NumRecursiveCalls { get; set; }
        public string StringOne { get; set; }
        public string StringTwo { get; set; }

        public EditDistanceRecursive()
        {
            NumRecursiveCalls = 0;
        }

        public void SetWords(string stringOne, string stringTwo)
        {
            StringOne = stringOne;
            StringTwo = stringTwo;
        }

        public double EditDistance(int i, int j)
        {
            NumRecursiveCalls++;
            if (j == 0)
                return i;
            if (i == 0)
                return j;

            return Min(
                    EditDistance(i - 1, j) + 1,
                    EditDistance(i, j - 1) + 1,
                    EditDistance(i - 1, j - 1) + Diff(StringOne[i], StringTwo[j]));
        }

        double Min(params double[] args)
        {
            var smallest = args[0];
            for (int i = 0; i < args.Length; i++)
                if (args[i] < smallest)
                    smallest = args[i];

            return smallest;
        }

        double Diff(char a, char b)
        {
            if (a == b)
                return 0;
            return 1;
        }

    }
}
