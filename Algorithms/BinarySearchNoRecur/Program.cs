using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchNoRecur
{
    /// <summary>
    /// 二分查找（非递归）
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 8, 10, 11, 67, 100 };
            int index = BinarySearch(arr, -1);
            Console.WriteLine(index);

            Console.ReadLine();
        }

        public static int BinarySearch(int[] arr,int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left<=right)
            {
                int mid = (left + right) / 2;
                if (arr[mid]==target)
                {
                    return mid;
                }
                else if (arr[mid]>target)//arr升序
                {
                    //向左边查找
                    right = mid - 1;
                }
                else
                {
                    //向右边查找
                    left = mid + 1;
                }
            }
            return -1;//没有找到
        }
    }
}
