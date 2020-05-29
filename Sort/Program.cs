using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 排序算法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //SortExample();

            CalTimeCost();

            Console.ReadKey();
        }


        private static void SortExample()
        {
            //int[] arr = { 0,0,0,0 };
            //int[] arr = { 3, 9, -1, 10, -2 };
            //int[] arr = { 8, 9, 1, 7, 2, 3, 5, 4, 6, 0 };
            int[] arr = { 8, 4, 5, 7, 1, 3, 4, 2 };


            //MySort.BubbleSort(arr);
            //MySort.SelectSort(arr);
            //MySort.InsertSort(arr);
            //MySort.ShellSort(arr, 1);
            //MySort.QuickSort(arr);
            MySort.MergeSort(arr);
            PrintArr(arr);
        }

        private static void CalTimeCost()
        {
            Random random = new Random();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            int[] arr = new int[80000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(8000000);
            }
            sw.Start();
            //MySort.BubbleSort(arr);//20s
            //MySort.SelectSort(arr);//7s
            //MySort.InsertSort(arr);//4.8s
            //MySort.ShellSort(arr, 0);//16s  交换太慢了
            //MySort.ShellSort(arr, 1);//0.023s
            //MySort.QuickSort(arr);//0.013s
            MySort.MergeSort(arr);//0.019s
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds.ToString());
        }

        private static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
