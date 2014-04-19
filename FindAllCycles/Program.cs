using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"../../Text/Graph3.txt");
            Graph graph = new Graph(sr);
            List<Cycle> cycles = graph.FindAllCycles();
        }
    }
}
