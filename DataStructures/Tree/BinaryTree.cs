using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree
    {
        public HeroNode Root { get; set; }

        //前序遍历
        public void PreOrder()
        {
            if (this.Root!=null)
            {
                this.Root.PreOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空，无法遍历");
            }
        }
        public HeroNode PreOrderSearch(int no)
        {
            if (this.Root!=null)
            {
                return Root.PreOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        //中序遍历
        public void InfixOrder()
        {
            if (this.Root != null)
            {
                this.Root.InfixOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空，无法遍历");
            }
        }
        public HeroNode InfixOrderSearch(int no)
        {
            if (this.Root != null)
            {
                return Root.InfixOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        //后续遍历
        public void PostOrder()
        {
            if (this.Root != null)
            {
                this.Root.PostOrder();
            }
            else
            {
                Console.WriteLine("二叉树为空，无法遍历");
            }
        }
        public HeroNode PostOrderSearch(int no)
        {
            if (this.Root != null)
            {
                return Root.PostOrderSearch(no);
            }
            else
            {
                return null;
            }
        }

        //删除
        public void DelNode(int no)
        {
            if (Root!=null)
            {
                if (Root.No==no)
                {
                    Root = null;
                }
                else
                {
                    Root.DelNode(no);
                }
            }
        }
    }
}
