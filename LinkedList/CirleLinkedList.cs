using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class CirleLinkedList
    {
        private Boy first;

        public void Create(int num)
        {
            if (num<1)
            {
                Console.WriteLine("num参数不正确，环形链表最小个数为1");
                return;
            }

            //循环创建对象，并形成环状
            Boy curBoy=null;//辅助指针
            for (int i = 1; i <= num; i++)
            {
                Boy boy = new Boy(i);
                if (i==1)
                {
                    first = boy;
                    first.Next = first;//形成环状

                    //让curBoy指向第一个，因为第一个不能动，后面让currBoy指针动
                    curBoy = first;
                }
                else
                {
                    curBoy.Next = boy;
                    boy.Next = first;//形成环状

                    curBoy = boy;//指针后移
                }
            }
        }

        public void ShowList()
        {
            if (first==null)
            {
                Console.WriteLine("链表为空");
                return;
            }

            //first不能动，需要辅助指针
            Boy curBoy = first;
            while (true)
            {
                Console.WriteLine(curBoy.ToString());
                if (curBoy.Next==first)
                {
                    break;
                }
                curBoy = curBoy.Next;
            }
        }

        public void Josepfu(int startNo,int countNum,int nums)
        {
            if (startNo<1||startNo>nums||first==null)
            {
                Console.WriteLine("参数有误");
                return;
            }

            //创建temp指针，指向first后面
            Boy temp = first;
            while (true)
            {
                if (temp.Next==first)
                {
                    break;
                }
                temp = temp.Next;
            }

            //报数前将first置于开始报数的小孩
            for (int i = 0; i < startNo-1; i++)
            {
                first = first.Next;
                temp = temp.Next;
            }

            //Console.WriteLine(first.ToString());
            //Console.WriteLine(temp.ToString());

            //开始报数
            while (true)
            {
                for (int j = 0; j < countNum-1; j++)
                {
                    first = first.Next;
                    temp = temp.Next;
                }

                //Console.WriteLine("头节点"+first.ToString());
                //Console.WriteLine("尾节点"+temp.ToString());

                //此时first指向的小孩要出局
                //Console.WriteLine("小孩{0}出局", first.No);

                first = first.Next;
                temp.Next = first;

                if (first==temp)
                {
                    //说明只有一个小孩
                    break;
                }
            }
            Console.WriteLine("最后留在圈中的小孩为"+first.ToString());
        }
    }
    class Boy
    {
        public int No { get; set; }
        public Boy Next { get; set; }
        public Boy(int no)
        {
            No = no;
        }
        public override string ToString()
        {
            return string.Format("小孩的编号为{0}", this.No);
        }
    }
}
