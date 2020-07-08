using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    /// <summary>
    /// 动态规划算法，以背包问题为例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] w = { 1, 4, 3 };              //物品重量
            int[] val = { 1500, 3000, 2000 };   //物品价值

            int m = 4;              //背包容量
            int n = val.Length;     //物品种类数

            //创建一个二维数组
            //注意，v[i,j] 表示 在前i个物品中 能够装入容量为j的背包 中的最大价值
            int[,] v = new int[n + 1, m + 1];

            //记录商品装入情况，和上面的二维数组一致
            int[,] path= new int[n + 1, m + 1];


            //初始化第一行，第一列（可不处理，默认为0）
            #region 初始化第一行，第一列
            //for (int i = 0; i < v.GetLength(0); i++)
            //{
            //    v[i, 0] = 0;//第一列置为0
            //}
            //for (int i = 0; i < v.GetLength(1); i++)
            //{
            //    v[0, i] = 0;//第一行置为0
            //} 
            #endregion

            Console.WriteLine("处理前");
            ShowArr(v);

            //动态规划处理表格
            for (int i = 1; i < v.GetLength(0); i++)//不处理第一列
            {
                for (int j = 1; j < v.GetLength(1); j++)//不处理第一行
                {
                    //公式
                    if (w[i-1]>j)
                    {
                        v[i, j] = v[i - 1, j];
                    }
                    else
                    {
                        //v[i, j] = Math.Max(v[i - 1, j], val[i - 1] + v[i - 1, j - w[i - 1]]);
                        if (v[i - 1, j]< val[i - 1] + v[i - 1, j - w[i - 1]])
                        {
                            v[i, j] = val[i - 1] + v[i - 1, j - w[i - 1]];
                            //记录当前情况
                            path[i, j] = 1;
                        }
                        else
                        {
                            v[i, j] = v[i - 1, j];
                        }
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine("处理后");
            ShowArr(v);
            ShowArr(path);

            Console.WriteLine();
            Console.WriteLine("放入背包的商品");

            //这样会输出所有情况
            //for (int i = 0; i < path.GetLength(0); i++)
            //{
            //    for (int j = 0; j < path.GetLength(1); j++)
            //    {
            //        if (path[i, j]==1)
            //        {
            //            Console.WriteLine("第"+i+"个商品放入背包");
            //        }
            //    }
            //}

            //只需要最后的放入情况
            int ii = path.GetLength(0) - 1;
            int jj = path.GetLength(1) - 1;
            while (ii > 0 && jj > 0)
            {
                if (path[ii, jj] == 1)
                {
                    Console.WriteLine("第" + ii + "个商品放入背包");
                    jj -= w[ii - 1];
                }
                ii--;
            }

            Console.ReadKey();
        }

        private static void ShowArr(int[,] v)
        {
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    Console.Write(v[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
