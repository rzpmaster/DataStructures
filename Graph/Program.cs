using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            string[] vertexValue = new string[] { "A", "B", "C", "D", "E" };
            Graph graph = new Graph(5);

            //添加顶点
            for (int i = 0; i < n; i++)
            {
                graph.InsertVertex(vertexValue[i]);
            }

            //添加边
            graph.InsertEdge(0, 1, 1);
            graph.InsertEdge(0, 2, 1);
            graph.InsertEdge(1, 2, 1);
            graph.InsertEdge(1, 3, 1);
            graph.InsertEdge(1, 4, 1);

            graph.ShowGraph();
            Console.WriteLine();
            graph.DFSShow();

            Console.ReadLine();
        }
    }
}
