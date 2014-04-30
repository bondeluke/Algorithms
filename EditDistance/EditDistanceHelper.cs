using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    public delegate double Difference(char a, char b);

    public static class EditDistanceHelper
    {

        public static double EditDistance(string x, string y, Difference Diff)
        {
            // Initialization
            int m = x.Length;
            int n = y.Length;
            double[][] E = new double[m][];
            for (int i = 0; i < m; i++)
                E[i] = new double[n];

            for (int i = 0; i < m; i++)
                E[i][0] = i;

            for (int j = 0; j < n; j++)
                E[0][j] = j;

            // Running the algorithm
            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    E[i][j] = Min(E[i - 1][j] + 1, E[i][j - 1] + 1, E[i - 1][j - 1] + Diff(x[i], y[j]));

            return E[m - 1][n - 1];
        }

        static double Min(params double[] args)
        {
            var smallest = args[0];
            for (int i = 0; i < args.Length; i++)
                if (args[i] < smallest)
                    smallest = args[i];

            return smallest;
        }

    }
}
