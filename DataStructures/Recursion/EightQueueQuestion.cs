using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    /// <summary>
    /// 八皇后问题
    /// </summary>
    class EightQueueQuestion
    {
        int max = 8;
        int[] array;
        int count = 0;
        int judgeCount = 0;
        public int GetCount()
        {
            return count;
        }
        public int GetJudgeCount()
        {
            return judgeCount;
        }
        public EightQueueQuestion()
        {
            array = new int[max];
        }

        //打印结果
        private void Print()
        {
            count++;
            for (int i = 0; i < max; i++)
            {
                Console.Write(array[i]+"\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 查看是否冲突
        /// 当摆放第n个时，就要检测前面n-1个是否与这个冲突
        /// </summary>
        /// <param name="n">表示第n个皇后/第n行的皇后</param>
        /// <returns></returns>
        private bool Judge(int n)
        {
            judgeCount++;
            for (int i = 0; i < n; i++)
            {
                if (array[i]==array[n]||//同一列
                    Math.Abs(n-i)==Math.Abs(array[n]-array[i]))//          行1-列1==行2-列2  
                                                               //也即是    行1-行2==列1-列2
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 放置第n个皇后
        /// </summary>
        /// <param name="n"></param>
        public void Check(int n)
        {
            if (n==max)
            {
                //8个皇后就已经放好了
                Print();
                return;
            }

            for (int i = 0; i < max; i++)
            {
                //先把第n个皇后放在改行的第一列(i=0)
                array[n] = i;
                //检查
                if (Judge(n))
                {
                    //不冲突，放第n+1个
                    Check(n + 1);
                }
                //如果冲突，i++，即放后一个位置
            }

        }
    }
}
