using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalCaseAlgorithm
{
    /// <summary>
    /// 克鲁斯卡尔算法 最小生成树
    /// </summary>
    class Program
    {
        //private const int INF = int.MaxValue;
        private const int INF = 10000;


        static void Main(string[] args)
        {
            char[] vertexs = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            int[,] matrix = new int[,]
            {
                {0,12,INF,INF,INF,16,14 },
                {12,0,10,INF,INF,7,INF },
                {INF,10,0,3,5,6,INF },
                {INF,INF,3,0,4,INF,INF },
                {INF,INF,5,4,0,2,8 },
                {16,7,6,INF,2,0,9 },
                {14,INF,INF,INF,8,9,0 }
            };

            KruskalCase kruskalCase = new KruskalCase(vertexs, matrix);
            kruskalCase.ShowGraph();
            kruskalCase.Kruskal();

            Console.ReadKey();
        }
    }
}
