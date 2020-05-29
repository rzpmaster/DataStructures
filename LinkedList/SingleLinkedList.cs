using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SingleLinkedList
    {
        //头节点
        private HeroNode head = new HeroNode(0, "", "");//不存放数据
        public HeroNode Head 
        {
            get
            {
                return head;
            } 
        }

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
                temp.Next = heroNode;       //新节点与前面关联
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
            //先找到该节点的前一个节点
            bool hasExisted = false;
            while (true)
            {
                if (temp.Next == null)
                {
                    //已经遍历完了，没找到
                    break;
                }
                if (temp.Next.No == heroNode.No)
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
                //将temp指向temp.Next.Next
                temp.Next = temp.Next.Next;
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

        public int GetLength()
        {
            int length = 0;
            if (head.Next == null)
            {
                return length;
            }
            HeroNode temp = head.Next;//没有包括头节点
            while (temp != null)
            {
                length++;
                temp = temp.Next;
            }
            return length;
        }

        //反转链表
        public void ReverseList()
        {
            //如果只有一个节点或者没有节点，直接返回，不用反转
            if (head.Next==null||head.Next.Next==null)
            {
                return;
            }

            HeroNode newHead = new HeroNode(0, "", "");
            HeroNode current = head.Next;
            HeroNode next = null;
            while (current!=null)
            {
                next = current.Next;    //将当前节点的后一个节点保存在next节点里

                //先连后面的
                current.Next = newHead.Next;    
                //将当前节点的后一个节点改为新链表已经排好的头节点后面的节点

                //在连前面的
                newHead.Next = current;         
                //将新链表头节点后面的改为当前节点（当前节点后面已经连好了之前连的节点）

                current = next;
            }

            //Console.WriteLine(this.GetLength());
            //为什么只有一个了，因为你第一次把current.Next = newHead.Next; 等于把第一个后面的节点值为空了，所以只有一个元素
            //newHead后面有四个成员

            //然后把头跟换了
            head.Next = newHead.Next;
            //Console.WriteLine(this.GetLength());
        }
    }
}
