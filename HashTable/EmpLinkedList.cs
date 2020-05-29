using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class EmpLinkedList
    {
        //头指针，指向第一个Emp
        private Emp head;

        //添加
        public void Add(Emp emp)
        {
            //如果是添加第一个雇员
            if (head==null)
            {
                head = emp;
                return;
            }
            //如果不是第一个，需要一个辅助指针指向最后
            Emp curEmp=head;
            while (true)
            {
                if (curEmp.Next==null)
                {
                    break;
                }
                curEmp = curEmp.Next;
            }
            curEmp.Next = emp;
        }

        //查找
        public Emp FindEmpById(int id)
        {
            if (head==null)
            {
                Console.WriteLine("链表为空");
                return null;
            }
            Emp currEmp = head;//辅助指针
            while (true)
            {
                if (currEmp.Id==id)
                {
                    //找到了
                    break;
                }
                currEmp = currEmp.Next;
                if (currEmp==null)
                {
                    //没找到
                    break;
                }
            }

            return currEmp;
        }

        //遍历链表的雇员信息
        public void ShowList()
        {
            if (head==null)
            {
                Console.WriteLine("当前链表为空");
                Console.WriteLine();
                return;
            }
            //Console.WriteLine("当前链表的信息为：");
            Emp currEmp = head;//辅助指针
            while (true)
            {
                Console.WriteLine(string.Format("雇员Id为 {0} Name为{1}", currEmp.Id, currEmp.Name));
                if (currEmp.Next==null)
                {
                    Console.WriteLine();//换行
                    return;
                }
                currEmp = currEmp.Next;
            }
        }
    }
}
