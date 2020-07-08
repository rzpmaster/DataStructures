using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    public class KMPAlgorithmDemo
    {
        public static int KMPSearch(string str1, string str2)
        {
            //获取部分匹配表
            int[] next = KMPNext(str2);

            //遍历str1
            for (int i = 0, j = 0; i < str1.Length; i++)
            {
                //当dest.ElementAt(i) != dest.ElementAt(j)时
                while (j > 0 && str1.ElementAt(i) != str2.ElementAt(j))//核心
                {
                    j = next[j - 1];//当匹配不到时，将j重置为部分匹配表中的前一个值
                }

                if (str1.ElementAt(i) == str2.ElementAt(j))
                {
                    j++;
                }
                if (j == str2.Length)
                {
                    return i - j + 1;
                }
            }

            return -1;
        }


        /// <summary>
        /// 获得字符串的 部分匹配表
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        private static int[] KMPNext(string dest)
        {
            int[] next = new int[dest.Length];
            next[0] = 0;
            for (int i = 1, j = 0; i < dest.Length; i++)
            {
                //当dest.ElementAt(i) != dest.ElementAt(j)时，我们需要从next[j-1]中获取新的j
                //直到dest.ElementAt(i) == dest.ElementAt(j)满足时推出
                while (j > 0 && dest.ElementAt(i) != dest.ElementAt(j))//核心
                {
                    j = next[j - 1];
                }

                //当dest.ElementAt(i) == dest.ElementAt(j)时，说明匹配上了
                if (dest.ElementAt(i) == dest.ElementAt(j))
                {
                    j++;
                }
                next[i] = j;
            }


            return next;
        }
    }
}
