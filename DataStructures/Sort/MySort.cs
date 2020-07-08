using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MySort
    {
        /// <summary>
        /// 冒泡排序：O(n^2)，稳
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            int temp = 0;
            bool isSwaped = false;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])//大的往后放
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSwaped = true;
                    }
                }

                //如果没有交换过，说明已经排好了
                if (isSwaped)
                {
                    isSwaped = false;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 选择排序：O(n^2)，不稳
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                int min = arr[minIndex];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)//找出最小值
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }

                //交换
                if (minIndex != i)//如果每次的第一个数就是最小值，不用交换
                {
                    arr[minIndex] = arr[i]; //第一个数放在最小值索引值处
                    arr[i] = min;           //最小值放第一个 
                }
            }
        }

        /// <summary>
        /// 插入排序：O(n^2)，稳
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int insertVal = arr[i];     //待插入的数
                int insertIndex = i - 1;    //待插入的数的前面的数的下标

                while (insertIndex >= 0 &&//保证给insertVal找位置时不越界
                    insertVal < arr[insertIndex])//insertVal还没有找到合适的位置
                {
                    //insertVal前面的数要往后移动，让出位置
                    arr[insertIndex + 1] = arr[insertIndex];
                    insertIndex--;//比较下一个数

                    //{ 101, 34, 119, 1} => { 101, 101, 119, 1} 待插入的数已经记录在insertVal了
                }

                //当推出while时，插入的位置已经找到，即 insertIndex+1 的位置
                if (insertIndex + 1 != i)
                {
                    arr[insertIndex + 1] = insertVal;
                }

            }
        }

        /// <summary>
        /// 希尔排序：O(n*log^2 n)，不稳
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="model">希尔排序方式，0：交换法；1：移动法</param>
        /// <remarks>改进的插入排序</remarks>
        public static void ShellSort(int[] arr, int model)
        {
            switch (model)
            {
                case 0:
                    ShellSortBySwap(arr);
                    break;
                case 1:
                    ShellSortByMove(arr);
                    break;
                default:
                    break;
            }
        }

        private static void ShellSortByMove(int[] arr)
        {
            int temp = 0;
            //增量step，并逐步缩小增量
            for (int step = arr.Length / 2; step > 0; step /= 2)//步长为1时，最后一遍排序
            {
                //外层循环宏观调控，共分为 arr.Length/2 组
                for (int i = step; i < arr.Length; i++)
                {
                    ////内层循环遍历每个组中的所有元素，
                    //for (int j = i - step; j >= 0; j -= step)
                    //{
                    //    if (arr[j] > arr[j + step])
                    //    {
                    //        temp = arr[j];
                    //        arr[j] = arr[j + step];
                    //        arr[j + step] = temp;
                    //    }
                    //}

                    //移位交换
                    int index = i;
                    temp = arr[index];
                    if (arr[index] < arr[index - step])
                    {
                        while (index - step >= 0 && temp < arr[index - step])
                        {
                            arr[index] = arr[index - step];
                            index -= step;
                        }
                        arr[index] = temp;
                    }
                }
            }
        }

        private static void ShellSortBySwap(int[] arr)
        {
            int temp = 0;
            //增量step，并逐步缩小增量
            for (int step = arr.Length / 2; step > 0; step /= 2)//步长为1时，最后一遍排序
            {
                //外层循环宏观调控，共分为 arr.Length/2 组
                for (int i = step; i < arr.Length; i++)
                {
                    //内层循环遍历每个组中的所有元素，
                    for (int j = i - step; j >= 0; j -= step)
                    {
                        if (arr[j] > arr[j + step])
                        {
                            temp = arr[j];
                            arr[j] = arr[j + step];
                            arr[j + step] = temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 快速排序：O(n*log n)，不稳
        /// </summary>
        /// <param name="arr"></param>
        /// <remarks>改进的冒泡排序</remarks>
        public static void QuickSort(int[] arr)
        {
            QuickSort2(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int leftIndex, int rightIndex)
        {
            int l = leftIndex;
            int r = rightIndex;
            int temp = 0;

            int pivot = arr[(leftIndex + rightIndex) / 2];
            //让 比pivot小的值放到左边， 比pivot大的值放到右边
            while (l < r)
            {
                //从pivot的左边一直找，直到找到一个比pivot大的值
                while (arr[l] < pivot)
                {
                    l += 1;
                }
                //从pivot的右边一直找，直到找到一个比pivot小的值
                while (arr[r] > pivot)
                {
                    r -= 1;
                }

                if (l == r)//说明pivot左右两边都已经局部有序了
                {
                    break;
                }

                //交换
                temp = arr[r];
                arr[r] = arr[l];
                arr[l] = temp;

                //交换完后确保不让指针所指的数和pivot相等
                if (arr[l] == pivot)
                {
                    r -= 1;
                }

                if (arr[r] == pivot)
                {
                    l += 1;
                }
            }

            //递归
            //递归之前，如果l==r，要让 l++ r-- ，否则会栈溢出
            if (l == r)
            {
                l += 1;
                r -= 1;
            }

            //向左递归
            if (leftIndex < r)
            {
                QuickSort(arr, leftIndex, r);
            }

            //向右递归
            if (rightIndex > l)
            {
                QuickSort(arr, l, rightIndex);
            }
        }

        private static void QuickSort2(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex) return;//只有一个元素

            //分区
            int pivot = arr[(leftIndex + rightIndex) / 2];
            int left = leftIndex;
            int right = rightIndex;

            int temp = 0;

            while (left < right)
            {
                while (arr[left] < pivot) left++;
                while (arr[right] > pivot) right--;

                if (left >= right) break;//排好了

                //交换
                temp = arr[right];
                arr[right] = arr[left];
                arr[left] = temp;

                //交换完后确保不让指针所指的数和pivot相等
                //如果没有这两句话，万一遇到和pivot相等的值将会形成死循环
                if (arr[left] == pivot) right--;
                if (arr[right] == pivot) left++;
            }

            //递归
            //递归之前，如果左右指针一样，会出现栈溢出（死循环）
            if (left == right)//这种情况只可能是左右指针同时指向pivot,手动调一下
            {
                left++;//注意这里有可能越界
                right--;
            }

            //递归左边
            if (right > leftIndex)
            {
                //这里不成立的情况：right < leftIndex 越界了
                //                  left = rightIndex 左边只剩一个元素，不用递归
                QuickSort2(arr, leftIndex, right);
            }
            //递归右边
            if (left < rightIndex)
            {
                //这里不成立的情况：left > rightIndex 越界了
                //                  left = rightIndex 右边只剩一个元素，不用递归
                QuickSort2(arr, left, rightIndex);
            }
        }

        /// <summary>
        /// 归并排序：O(n*log n)，稳
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            MergeSort(arr, 0, arr.Length - 1, temp);
        }

        private static void MergeSort(int[] arr,int left,int right,int[] temp)
        {
            //if (arr.Length < 2) return;
            if (left<right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid, temp);
                MergeSort(arr, mid + 1, right, temp);
                Merge(arr, left, right, mid, temp);
            }
        }

        private static void Merge(int[] arr, int left, int right, int mid, int[] temp)
        {
            int i = left;//左边有序数组的初始索引
            int j = mid + 1;//右边有序数组的初始索引

            int t = 0;//temp数组的指针
            while (i <= mid && j <= right)//依次放入有序数组temp
            {
                if (arr[i] <= arr[j])
                {
                    temp[t++] = arr[i++];
                }
                else
                {
                    temp[t++] = arr[j++];
                }
            }

            //如果有剩余的元素 也依次放到temp数组中
            while (i<=mid)
            {
                temp[t++] = arr[i++];
            }
            while (j<=right)
            {
                temp[t++] = arr[j++];
            }

            //将temp数组拷贝到原数组中
            //int tempLeft = left;//临时指针，指向左数组
            //t = 0;
            //Console.WriteLine("tempLeft={0},right={1}",tempLeft,right);
            //while (tempLeft<=right)
            //{
            //    arr[tempLeft++]=temp[t++];
            //}

            for (int k = 0; k < t; k++)
            {
                arr[left + k] = temp[k];
            }
        }
    }//end class
}
