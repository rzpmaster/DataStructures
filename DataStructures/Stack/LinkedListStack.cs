using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace Stack
{
    class LinkedListStack
    {
        private int maxSize;
        private SingleLinkedList stack;
        private int top
        {
            get
            {
                return stack.GetLength();
            }
        }

        public LinkedListStack(int maxSize)
        {
            this.maxSize = maxSize;
            stack = new SingleLinkedList();
        }

        //栈满
        public bool IsFull()
        {
            return top == maxSize;
        }

        //栈空
        public bool IsEmpty()
        {
            return top == 0;
        }

        //压栈
        public void Push(HeroNode value)
        {
            if (IsFull())
            {
                Console.WriteLine("栈满");
                return;
            }
            stack.Add(value);
        }

        //出栈
        public HeroNode Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空");
                throw new Exception();
            }
            HeroNode value = stack.Head;
            while (value.Next!=null)
            {
                value = value.Next;
            }
            HeroNode heroNode = value;
            stack.Delete(value);

            return heroNode;
        }

        //遍历栈
        public void ShowList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("栈空");
            }
            HeroNode temp = stack.Head;
            Stack<HeroNode> heroNodes = new Stack<HeroNode>();
            while (temp.Next!=null)
            {
                temp = temp.Next;
                heroNodes.Push(temp);
            }
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(heroNodes.Pop().ToString());
            }
        }
    }
}
