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
            StreamReader sr = new StreamReader(@"../../Text/Graph1.txt");
            Graph graph = new Graph(sr);

            int budget = 5;
            List<Node> vertexCover = graph.FindVertexCover(budget);
            if (vertexCover == null)
                Console.WriteLine(String.Format("There is no vertex cover if we only allow {0} vertices!", budget));
            else
                Console.WriteLine(String.Format("There is a vertex cover if we allow {0} up to vertices!", budget));

            Console.ReadLine();
        }
    }
}
