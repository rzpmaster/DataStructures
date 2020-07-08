using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// 链表
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //HeroNode hero1 = new HeroNode(1, "宋江", "及时雨");
            //HeroNode hero2 = new HeroNode(2, "卢俊义", "玉麒麟");
            //HeroNode hero3 = new HeroNode(3, "吴用", "智多星");
            //HeroNode hero4 = new HeroNode(4, "林冲", "豹子头");

            #region 单向链表
            //SingleLinkedList list = new SingleLinkedList();

            ////list.Add(hero1);
            ////list.Add(hero4);
            ////list.Add(hero2);
            ////list.Add(hero3);
            //Console.WriteLine("按顺序添加");
            //list.AddByOrder(hero1);
            //list.AddByOrder(hero4);
            //list.AddByOrder(hero2);
            //list.AddByOrder(hero3);
            //list.AddByOrder(hero3);
            //list.ShowList();
            //Console.WriteLine();

            //list.ReverseList();
            //Console.WriteLine("反转后的链表为");
            //list.ShowList();

            ///*
            //Console.WriteLine("修改");
            //HeroNode newHeroNode=new HeroNode(2, "小卢", "玉麒麟~~~");
            //list.Update(newHeroNode);
            //list.ShowList();
            //Console.WriteLine();

            //Console.WriteLine("删除");
            //list.Delete(hero1);
            //list.Delete(hero4);
            //list.Delete(hero2);
            //list.Delete(hero2);
            //list.ShowList();
            //Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("链表的有效节点数为{0}个",list.GetLength());
            //*/ 
            #endregion

            #region 双向链表
            //DoubleLinkedList list = new DoubleLinkedList();
            ////list.Add(hero1);
            ////list.Add(hero2);
            ////list.Add(hero3);
            ////list.Add(hero4);
            //list.AddByOrder(hero1);
            //list.AddByOrder(hero4);
            //list.AddByOrder(hero2);
            //list.AddByOrder(hero3);
            //list.AddByOrder(hero3);

            //list.ShowList();
            //Console.WriteLine();

            //HeroNode hero5 = new HeroNode(4, "公孙胜", "入云龙");
            //list.Update(hero5);
            //list.ShowList();
            //Console.WriteLine();

            //list.Delete(hero3);
            //list.ShowList();
            //Console.WriteLine();

            #endregion

            #region 单向环形链表和约瑟夫问题
            CirleLinkedList list = new CirleLinkedList();
            list.Create(5);
            //list.ShowList();
            Console.WriteLine();

            list.Josepfu(1, 2, 5);

            #endregion

            Console.ReadKey();
        }
    }
}
