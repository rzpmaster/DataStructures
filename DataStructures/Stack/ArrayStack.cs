using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class ArrayStack
    {
        private int maxSize;
        private int[] stack;
        private int top=-1;

        public ArrayStack(int maxSize)
        {
            this.maxSize = maxSize;
            stack = new int[this.maxSize];
        }

        //栈满
        public bool IsFull()
        {
            return top == maxSize - 1;
        }

        //栈空
        public bool IsEmpty()
        {
            return top == -1;
        }

        //压栈
        public void Push(int value)
        {
            if (IsFull())
            {
                Console.WriteLine("栈满");
                return;
            }
            top++;
            stack[top] = value;
        }

        //出栈
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空");
                throw new Exception();
            }
            int value = stack[top];
            top--;
            return value;
        }

        //看一下栈定的值
        public int Peek()
        {
            return stack[top];
        }

        //遍历栈
        public void ShowList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空");
            }
            for (int i = top; i >=0; i--)
            {
                Console.WriteLine(stack[i].ToString());
            }
        }
    }
}
