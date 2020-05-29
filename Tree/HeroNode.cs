using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class HeroNode
    {
        public int No { get; set; }
        public string Name { get; set; }
        public HeroNode Left { get; set; }
        public HeroNode Right { get; set; }
        public HeroNode(int no, string name)
        {
            this.No = no;
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("排名：{0}\t名字：{1}", No, Name);
        }

        //前序遍历
        public void PreOrder()
        {
            Console.WriteLine(this);//输出当前节点

            //递归向左子节点
            if (this.Left != null)
            {
                this.Left.PreOrder();
            }
            //递归向右子节点
            if (this.Right != null)
            {
                this.Right.PreOrder();
            }
        }
        public HeroNode PreOrderSearch(int no)
        {
            Console.WriteLine("进入前序遍历~~~");
            HeroNode resNode = null;
            //比较当前节点
            if (this.No==no)
            {
                resNode = this;
                return resNode;
            }
            //向左递归
            if (this.Left!=null)
            {
                resNode = this.Left.PreOrderSearch(no);
            }
            if (resNode!=null)
            {
                return resNode;
            }
            //向右递归
            if (this.Right!=null)
            {
                resNode = this.Right.PreOrderSearch(no);
            }
            return resNode; 
        }

        //中序遍历
        public void InfixOrder()
        {
            //递归向左子节点
            if (this.Left != null)
            {
                this.Left.InfixOrder();
            }
            Console.WriteLine(this);//输出当前节点
            //递归向右子节点
            if (this.Right != null)
            {
                this.Right.InfixOrder();
            }
        }
        public HeroNode InfixOrderSearch(int no)
        {
            HeroNode resNode = null;
            //向左递归
            if (this.Left != null)
            {
                resNode = this.Left.InfixOrderSearch(no);
            }
            if (resNode != null)
            {
                return resNode;
            }
            Console.WriteLine("进入中序遍历~~~");//主要是看进行了几次判断，不写在前面是因为他有可能是进来看看是不是空，关键时看比较了几次
            //比较当前节点
            if (this.No == no)
            {
                resNode = this;
                return resNode;
            }
            //向右递归
            if (this.Right != null)
            {
                resNode = this.Right.InfixOrderSearch(no);
            }
            return resNode;
        }

        //后续遍历
        public void PostOrder()
        {
            //递归向左子节点
            if (this.Left != null)
            {
                this.Left.PostOrder();
            }
            //递归向右子节点
            if (this.Right != null)
            {
                this.Right.PostOrder();
            }
            Console.WriteLine(this);//输出当前节点
        }
        public HeroNode PostOrderSearch(int no)
        {
            HeroNode resNode = null;
            //向左递归
            if (this.Left != null)
            {
                resNode = this.Left.PostOrderSearch(no);
            }
            if (resNode != null)
            {
                return resNode;
            }
            //向右递归
            if (this.Right != null)
            {
                resNode = this.Right.PostOrderSearch(no);
            }
            if (resNode!=null)
            {
                return resNode;
            }
            Console.WriteLine("进入后序遍历~~~");//主要是看进行了几次判断，不写在前面是因为他有可能是进来看看是不是空，关键时看比较了几次
            //比较当前节点
            if (this.No == no)
            {
                resNode = this;
            }
            return resNode;
        }

        //删除
        public void DelNode(int no)
        {
            if (this.Left!=null&& this.Left.No==no)
            {
                this.Left = null;
                return;
            }
            if (this.Right!=null&&this.Right.No==no)
            {
                this.Right = null;
                return;
            }

            //递归
            if (this.Left!=null)
            {
                this.Left.DelNode(no);
            }
            if (this.Right != null)
            {
                this.Right.DelNode(no);
            }
        }
    }
}
