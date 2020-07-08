using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideAndConquer
{
    /// <summary>
    /// 分治算法，以汉诺塔为例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            HanoiTower(5, 'A', 'B', 'C');

            Console.ReadKey();
        }

        public static void HanoiTower(int num,char a,char b,char c)
        {
            if (num==1)
            {
                //直接将A盘移动到C盘结束
                Console.WriteLine("第"+num+"个盘\t"+a+"->"+c);
            }
            else
            {
                //将n>=2的情况看成：1.最下面一个盘；2.上面所有盘

                //1.先把最上面所有盘从A->B，移动过程中会使用到C
                HanoiTower(num - 1, a, c, b);//注意这里的顺序

                //2.把最下面的盘从A->C
                Console.WriteLine("第" + num + "个盘\t" + a + "->" + c);

                //3.把B塔的所有盘移动到C，移动过程中会使用到A
                HanoiTower(num - 1, b, a, c);//注意这里的顺序
            }
        }
    }
}
