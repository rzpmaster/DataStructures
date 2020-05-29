using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable
    {
        private EmpLinkedList[] empLinkedListArray;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
            empLinkedListArray = new EmpLinkedList[this.size];

            //注意，这里要初始化所有链表
            for (int i = 0; i < size; i++)
            {
                empLinkedListArray[i] = new EmpLinkedList();
            }
        }

        //添加
        public void Add(Emp emp)
        {
            //根据员工的Id，判断员工应该加到哪个链表中
            int empLinkedListIndex = HashFun(emp.Id);
            empLinkedListArray[empLinkedListIndex].Add(emp);
        }

        //遍历所有链表信息
        public void ShowHashTable()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Format("第 {0} 个链表中的雇员有",i));
                empLinkedListArray[i].ShowList();
            }
        }

        //查找
        public void FindEmpById(int id)
        {
            int empLinkedListIndex = HashFun(id);
            Emp emp = empLinkedListArray[empLinkedListIndex].FindEmpById(id);
            if (emp!=null)
            {
                Console.WriteLine(string.Format("在第{0}个链表中找到了该雇员", empLinkedListIndex));
            }
            else
            {
                Console.WriteLine("没有找到");
            }
        }

        //散列函数
        public int HashFun(int id)
        {
            return id % size;
        }
    }
}
