using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm
{
    /// <summary>
    /// 普利姆算法求最小生成树，解决修路问题
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'A', 'B', 'C', 'D', 'E', 'F','G' };
            int verxs = data.Length;
            int[,] weight = new int[,]//10000表示不连通
            {
                { 10000,5,7,10000,10000,10000,2},
                { 5,10000,10000,9,10000,10000,3},
                { 7,10000,10000,10000,8,10000,10000},
                { 10000,9,10000,10000,10000,4,10000},
                { 10000,10000,8,10000,10000,5,4},
                { 10000,10000,10000,4,5,10000,6},
                { 2,3,10000,10000,4,6,10000}
            };

            GraphMap graph = new GraphMap(verxs);
            MinTree minTree = new MinTree();
            minTree.CreateGraph(graph, verxs, data, weight);
            minTree.ShowGraph(graph);
            Console.WriteLine();

            Console.WriteLine("普利姆算法");
            minTree.Prim(graph, 0);

            Console.ReadKey();

        }
    }
}
