using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    /// <summary>
    /// 暴力匹配
    /// </summary>
    public class ViolenceMatchDemo
    {
        public static int ViolenceMatch(string str1,string str2)
        {
            char[] s1 = str1.ToCharArray();
            char[] s2 = str2.ToCharArray();

            int s1Len = s1.Length;
            int s2Len = s2.Length;

            int i=0, j=0;
            while (i<s1Len&&j<s2Len)
            {
                if (s1[i]==s2[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - (j - 1);
                    j = 0;
                }
            }

            if (j==s2Len)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }
    }
}
