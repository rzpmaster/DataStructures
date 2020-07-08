using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class DoubleLinkedList
    {
        //头节点
        private HeroNode head = new HeroNode(0, "", "");//不存放数据

        //添加节点到链表最后
        public void Add(HeroNode heroNode)
        {
            //head节点不能动，需要一个辅助指针
            HeroNode temp = head;
            //遍历链表，找到最后节点
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            //连上新节点
            temp.Next = heroNode;
            heroNode.Pre = temp;
        }

        //按顺序添加到链表
        public void AddByOrder(HeroNode heroNode)
        {
            //head节点不能动，需要一个辅助指针
            HeroNode temp = head;
            //遍历链表，找到要加入位置的前一个节点
            bool hasExisted = false;
            while (true)
            {
                if (temp.Next == null)
                {
                    break;//从这里推出，说明没有找到，那就是最后添加
                }

                if (temp.Next.No > heroNode.No)
                {
                    //temp后面的节点的No值比需要插入的节点大
                    //说明找到位置了
                    break;
                }
                else if (temp.Next.No == heroNode.No)
                {
                    //说明已经存在了
                    hasExisted = true;
                    break;
                }
                else
                {
                    //说明temp.Next.No < heroNode.No 继续循环继续找
                    temp = temp.Next;
                }
            }

            //将新节点插入到temp和temp.Next中间
            if (hasExisted)
            {
                Console.WriteLine("排名为 {0} 的英雄 {1} 已经存在，不能重复添加", temp.No, temp.Name);
                return;
            }
            else
            {
                heroNode.Next = temp.Next;  //新节点与后面的关联
                heroNode.Pre = temp;
                temp.Next = heroNode;       //新节点与前面关联
                temp.Pre = heroNode;
            }
        }

        //修改节点信息
        public void Update(HeroNode heroNode)
        {
            if (head.Next == null)
            {
                Console.WriteLine("链表为空");
            }
            HeroNode temp = head.Next;
            //先找到该节点
            bool hasExisted = false;
            while (true)
            {
                if (temp == null)
                {
                    //已经遍历完了，没找到
                    break;
                }
                if (temp.No == heroNode.No)
                {
                    hasExisted = true;
                    break;
                }
                else
                {
                    temp = temp.Next;
                }
            }
            if (hasExisted)
            {
                temp.Name = heroNode.Name;
                temp.Nickname = heroNode.Nickname;
            }
            else
            {
                Console.WriteLine("修改时有找到编号为{0}的英雄节点", heroNode.No);
            }
        }

        //删除节点
        public void Delete(HeroNode heroNode)
        {
            if (head.Next == null)
            {
                Console.WriteLine("链表为空");
            }
            HeroNode temp = head;
            //先找到该节点
            bool hasExisted = false;
            while (true)
            {
                if (temp.Next == null)
                {
                    //已经遍历完了，没找到
                    break;
                }
                if (temp.No == heroNode.No)
                {
                    hasExisted = true;
                    break;
                }
                else
                {
                    temp = temp.Next;
                }
            }
            if (hasExisted)
            {
                //删除
                temp.Pre.Next = temp.Next;
                //temp.Next.Pre = temp.Pre;//有风险，如果是删除最后一个节点会有问题
                if (temp.Next!=null)
                {
                    temp.Next.Pre = temp.Pre;
                }
            }
            else
            {
                Console.WriteLine("删除时没有有找到编号为{0}的英雄节点", heroNode.No);
            }
        }

        public void ShowList()
        {
            if (head.Next == null)
            {
                Console.WriteLine("链表为空");
                return;
            }

            HeroNode temp = head.Next;//从头节点的后一个开始输出
            while (temp != null)
            {
                //输出节点信息
                Console.WriteLine(temp.ToString());
                temp = temp.Next;
            }
        }
    }
}
