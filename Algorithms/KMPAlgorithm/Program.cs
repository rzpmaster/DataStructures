using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    /// <summary>
    /// KMP算法 字符串匹配 优于暴力匹配
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "BBC ABCDAB ABCDABCDABDE";
            string str2 = "ABCDABC";


            //测试暴力匹配
            #region 测试暴力匹配
            //int index = ViolenceMatchDemo.ViolenceMatch(str1, str2);
            //Console.WriteLine(index);//15 
            #endregion

            int index = KMPAlgorithmDemo.KMPSearch(str1,str2);
            Console.WriteLine(index);//15 

            Console.ReadLine();
        }

        private static void Print(int[] next)
        {
            for (int i = 0; i < next.Length; i++)
            {
                Console.Write(next[i]+"\t");
            }
            Console.WriteLine();
        }
    }
}
