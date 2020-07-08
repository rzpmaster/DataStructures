using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class ArrayQueue
    {
        private int maxSize;
        private int front;      //队列头
        private int rear;       //队列尾
        private int[] arr;

        public ArrayQueue(int arrMaxSize)
        {
            maxSize = arrMaxSize;
            arr = new int[maxSize];
            front = -1;
            rear = -1;
        }

        public bool IsFull()
        {
            return rear == maxSize - 1;
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
            arr[rear++] = n;
        }

        public int GetQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，无法取出");
                Console.ReadLine();
                throw new Exception("队列空，无法取出");
            }
            return arr[front++];
        }

        public void ShowQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，没有数据");
                Console.ReadLine();
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
                Console.ReadLine();
            }
        }

        public int ShowHeadQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("队列空，没有数据");
                Console.ReadLine();
                throw new Exception("队列空，没有数据");
            }
            return arr[front + 1];//注意不是取出
        }
    }
}
