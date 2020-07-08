using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseChess
{
    /// <summary>
    /// 马踏棋盘问题
    /// </summary>
    class Program
    {
        public static int X;//表示列
        public static int Y;//表示行

        //标记棋盘的位置是否被访问过
        private static bool[] visited;
        private static bool finished;

        static void Main(string[] args)
        {
            //棋盘大小
            X = 8;
            Y = 8;

            //开始位置
            int row = 1;
            int column = 1;

            //棋盘
            int[,] chessboard = new int[X, Y];
            visited = new bool[X * Y];

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            TraversalChessBoard(chessboard, row - 1, column - 1, 1);

            // 6阶->0.081s

            // 8阶->110s  优化后0.028s

            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds.ToString());

            Console.WriteLine();
            //输出棋盘信息
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    Console.Write(chessboard[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static void TraversalChessBoard(int[,] chessboard, int row, int colum, int step)
        {
            chessboard[row, colum] = step;
            visited[row * X + colum] = true;//标记为访问过

            //获取马能走的位置
            List<Tuple<int, int>> ps = Next(new Tuple<int, int>(colum, row));

            #region 优化
            //当前步数的下一步可能性较少的,有限选择
            Sort(ps);
            #endregion

            //遍历
            while (ps.Count() != 0)
            {
                //取出一个可以走的位置
                Tuple<int, int> p = ps[0];
                ps.RemoveAt(0);
                if (!visited[p.Item2 * X + p.Item1])
                {
                    TraversalChessBoard(chessboard, p.Item2, p.Item1, step + 1);
                }
            }

            //判断是否成功
            //step < X * Y 成立有两种情况:
            //1.棋盘到目前为止,没有走完
            //2.棋盘处于回溯过程
            if (step < X * Y && !finished)
            {
                chessboard[row, colum] = 0;
                visited[row * X + colum] = false;
            }
            else
            {
                finished = true;
            }
        }

        /// <summary>
        /// 根据当前的位置,计算马还能跑那些位置点
        /// </summary>
        /// <param name="currPoint"></param>
        /// <returns></returns>
        public static List<Tuple<int, int>> Next(Tuple<int, int> currPoint)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
            if (currPoint.Item1 - 2 >= 0 && currPoint.Item2 - 1 >= 0)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 - 2, currPoint.Item2 - 1));
            }
            if (currPoint.Item1 - 1 >= 0 && currPoint.Item2 - 2 >= 0)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 - 1, currPoint.Item2 - 2));
            }
            if (currPoint.Item1 + 1 < X && currPoint.Item2 - 2 >= 0)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 + 1, currPoint.Item2 - 2));
            }
            if (currPoint.Item1 + 2 < X && currPoint.Item2 - 1 >= 0)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 + 2, currPoint.Item2 - 1));
            }
            if (currPoint.Item1 + 2 < X && currPoint.Item2 + 1 < Y)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 + 2, currPoint.Item2 + 1));
            }
            if (currPoint.Item1 + 1 < X && currPoint.Item2 + 2 < Y)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 + 1, currPoint.Item2 + 2));
            }
            if (currPoint.Item1 - 1 >= 0 && currPoint.Item2 + 2 < Y)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 - 1, currPoint.Item2 + 2));
            }
            if (currPoint.Item1 - 2 >= 0 && currPoint.Item2 + 1 < Y)
            {
                tuples.Add(new Tuple<int, int>(currPoint.Item1 - 2, currPoint.Item2 + 1));
            }

            return tuples;
        }

        //
        //优化
        //

        //根据当前这一步的所有下一步的可选择的可能性个数,非递减排下序
        public static void Sort(List<Tuple<int, int>> ps)
        {
            ps.Sort((x, y) =>
            {
                if (Next(x).Count() < Next(y).Count())
                {
                    return -1;
                }
                else if (Next(x).Count() == Next(y).Count())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            });
        }
    }
}
