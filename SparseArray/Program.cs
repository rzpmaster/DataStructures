using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseArray
{
    /// <summary>
    /// 稀疏数组
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //1 创建一个原始的数组
            int[,] chessArr1 = new int[11,11];
            chessArr1[1, 2] = 1;
            chessArr1[2, 4] = 2;
            chessArr1[4, 5] = 2;

            Console.WriteLine("原数组为");
            for (int i = 0; i < chessArr1.GetLength(0); i++)
            {
                for (int j = 0; j < chessArr1.GetLength(1); j++)
                {
                    Console.Write(chessArr1[i,j]+"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("=========================================================");

            //2 转为稀疏数组
            int sum = 0;
            for (int i = 0; i < chessArr1.GetLength(0); i++)
            {
                for (int j = 0; j < chessArr1.GetLength(1); j++)
                {
                    if (chessArr1[i, j] != 0) sum++;
                }
            }
            Console.WriteLine("原数组中有{0}个数据",sum);

            int[,] sparseArr = new int[sum + 1, 3];
            sparseArr[0, 0] = 11;
            sparseArr[0, 1] = 11;
            sparseArr[0, 2] = sum;
            int count = 0;
            for (int i = 0; i < chessArr1.GetLength(0); i++)
            {
                for (int j = 0; j < chessArr1.GetLength(1); j++)
                {
                    if (chessArr1[i, j] == 0) continue;
                    count++;//从第1行开始记录卡
                    sparseArr[count, 0] = i;
                    sparseArr[count, 1] = j;
                    sparseArr[count, 2] = chessArr1[i,j];
                }
            }

            Console.WriteLine("转化为稀疏数组为");
            for (int i = 0; i < sparseArr.GetLength(0); i++)
            {
                for (int j = 0; j < sparseArr.GetLength(1); j++)
                {
                    Console.Write(sparseArr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("=========================================================");

            //3 将稀疏数组转化成数组
            int[,] chessArr2 = new int[sparseArr[0, 0], sparseArr[0, 1]];
            for (int i = 1; i < sparseArr.GetLength(0); i++)
            {
                chessArr2[sparseArr[i, 0], sparseArr[i, 1]] = sparseArr[i, 2];
            }

            Console.WriteLine("转化为数组为");
            for (int i = 0; i < chessArr2.GetLength(0); i++)
            {
                for (int j = 0; j < chessArr2.GetLength(1); j++)
                {
                    Console.Write(chessArr2[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
