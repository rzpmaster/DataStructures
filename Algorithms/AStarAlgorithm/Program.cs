using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    /// <summary>
    /// Astar算法
    /// </summary>
    class Program
    {
        static int[,] map;
        static void Main(string[] args)
        {
            AStarManager aStarManager = AStarManager.Instance;
            map = new int[,]
            {
                { 0,0,0,0,1,0,0,0,0},
                { 0,0,0,0,1,0,0,0,0},
                { 0,0,0,0,1,0,0,0,0},
                { 0,0,0,0,1,0,0,0,0},
                { 0,0,0,0,1,0,0,0,0},
                { 0,0,0,0,1,1,1,0,1},
                { 0,0,0,0,0,0,0,0,0}
            };


            aStarManager.InitMap(map);

            var path = aStarManager.FindPath(new System.Numerics.Vector2(4, 1), new System.Numerics.Vector2(1, 7));

            PrintMap(path);

            Console.ReadLine();
        }

        private static void PrintMap(List<AstarNode> path)
        {
            if (path != null)
            {
                foreach (var item in path)
                {
                    var x = item.x;
                    var y = item.y;
                    map[x, y] = 8;
                }

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
