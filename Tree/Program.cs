using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //先创建一个二叉树
            BinaryTree binaryTree = new BinaryTree();

            //英雄节点
            HeroNode sj = new HeroNode(1, "songjiang");
            HeroNode wy = new HeroNode(2, "wuyong");
            HeroNode ljy = new HeroNode(3, "lujunyi");
            HeroNode lc = new HeroNode(4, "lingchong");
            HeroNode gs = new HeroNode(5, "gaunsheng");

            #region 手动创建
            binaryTree.Root = sj;
            sj.Left = wy;
            sj.Right = ljy;
            ljy.Left = gs;
            ljy.Right = lc;
            #endregion

            //
            //测试
            //


            //binaryTree.PreOrder();//1234    121354
            //binaryTree.InfixOrder();//2134  21534
            //binaryTree.PostOrder();//2431   25431

            //HeroNode heroNode = binaryTree.PreOrderSearch(5);//4
            //HeroNode heroNode = binaryTree.InfixOrderSearch(5);//3
            //HeroNode heroNode = binaryTree.PostOrderSearch(5);//2

            //if (heroNode!=null)
            //{
            //    Console.WriteLine("找到了\n"+heroNode);
            //}
            //else
            //{
            //    Console.WriteLine("没找到");
            //}

            Console.WriteLine("删除前");
            binaryTree.PreOrder();
            binaryTree.DelNode(3);
            Console.WriteLine();
            Console.WriteLine("删除后");
            binaryTree.PreOrder();

            Console.ReadKey();
        }
    }
}
