using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlgorithm
{
    /// <summary>
    /// 佛洛依德算法,最小路径问题
    /// </summary>
    class Program
    {
        const int N = 65535;
        static void Main(string[] args)
        {
            char[] vertex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            int[,] matrix = new int[,]
            {
                {0,5,7,N,N,N,2 },
                {5,0,N,9,N,N,3 },
                {7,N,0,N,8,N,N },
                {N,9,N,0,N,4,N },
                {N,N,8,N,0,5,4 },
                {N,N,N,4,5,0,6 },
                {2,3,N,N,4,6,0 }
            };

            Floyd floyd = new Floyd(vertex.Length, matrix, vertex);
            floyd.Show();
            floyd.FloydAlgorithm();
            Console.WriteLine();
            Console.WriteLine("佛洛依德算法");
            floyd.Show();

            Console.ReadKey();
        }
    }
}
