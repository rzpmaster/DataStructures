using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class CircleArrayQueue
    {
        private int maxSize;
        private int front;      //队列头
        private int rear;       //队列尾
        private int[] arr;

        public CircleArrayQueue(int arrMaxSize)
        {
            maxSize = arrMaxSize;
            arr = new int[maxSize];
            //front = 0;
            //rear = 0;
        }

        public bool IsFull()
        {
            return (rear + 1) % maxSize == front;
        }

        public bool IsEmpty()
        {
            return rear == front;
        }

        public void AddQueue(int n)
        {
            if (IsFull())
            {
                Console.WriteLine("队列满，无法加入");
                Console.ReadLine();
                return;
            }
            arr[rear] = n;//rear指向最后一个元素的后一个位置，直接赋值
            //将rear后移
            //rear++;//要考虑环形队列，数组越界
            rear = (rear + 1) % maxSize;
        }

        public int GetQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，无法取出");
                Console.ReadLine();
                throw new Exception("队列空，无法取出");
            }
            //front指向队列的第一个元素

            //先把front的值保存在一个临时变量中，然后将front后移，然后将临时变量返回
            int value = arr[front];
            //front++;//要考虑环形队列，数组越界
            front = (front + 1) % maxSize;
            return value;
        }

        public void ShowQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，没有数据");
                Console.ReadLine();
            }
            //从front开始遍历，遍历当前数组的个数
            for (int i = front; i < front+GetSize(); i++)
            {
                Console.Write(arr[i%maxSize] + "\t");
                Console.ReadLine();
            }
        }

        public int GetSize()
        {
            return (rear + maxSize - front) % maxSize;
        }

        public int ShowHeadQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，没有数据");
                Console.ReadLine();
                throw new Exception("队列空，没有数据");
            }
            return arr[front];//注意不是取出
        }
    }
}
