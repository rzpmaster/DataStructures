using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
{
    /// <summary>
    /// 贪心算法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //创建广播电调，放入Map中
            Dictionary<string, HashSet<string>> broadCasts = new Dictionary<string, HashSet<string>>();
            HashSet<string> hashSet1 = new HashSet<string>();
            hashSet1.Add("北京");
            hashSet1.Add("上海");
            hashSet1.Add("天津");
            HashSet<string> hashSet2 = new HashSet<string>();
            hashSet2.Add("广州");
            hashSet2.Add("北京");
            hashSet2.Add("深圳");
            HashSet<string> hashSet3 = new HashSet<string>();
            hashSet3.Add("成都");
            hashSet3.Add("上海");
            hashSet3.Add("杭州");
            HashSet<string> hashSet4 = new HashSet<string>();
            hashSet4.Add("上海");
            hashSet4.Add("天津");
            HashSet<string> hashSet5 = new HashSet<string>();
            hashSet5.Add("杭州");
            hashSet5.Add("大连");

            broadCasts.Add("K1", hashSet1);
            broadCasts.Add("K2", hashSet2);
            broadCasts.Add("K3", hashSet3);
            broadCasts.Add("K4", hashSet4);
            broadCasts.Add("K5", hashSet5);

            //存放所有地区
            HashSet<string> allAreas = new HashSet<string>();
            foreach (var hashSet in broadCasts.Values)
            {
                foreach (var item in hashSet)
                {
                    if (!allAreas.Contains(item))
                    {
                        allAreas.Add(item);
                    }
                }
            }

            //存放选择的电台集合
            List<string> selects = new List<string>();

            //定义一个临时的集合，存放遍历过程中的电台覆盖的地区和当前还没有覆盖的地区的交集
            HashSet<string> tempSet = new HashSet<string>();

            //max指针
            string maxKay = null;
            while (allAreas.Count!=0)
            {
                foreach (var broadCast in broadCasts)
                {
                    tempSet.Clear();//每次循环前置空temp
                    HashSet<string> areas = broadCast.Value;
                    foreach (var item in areas)
                    {
                        tempSet.Add(item);
                    }

                    tempSet.IntersectWith(allAreas);
                    if (tempSet.Count>0&&
                        (maxKay==null||tempSet.Count> broadCasts[maxKay].Count))
                    {
                        maxKay = broadCast.Key;
                    }

                    //将maxKay加入selects集合，并在allAreas中取出相应地区
                    if (maxKay != null)
                    {
                        selects.Add(maxKay);
                        foreach (var item in broadCasts[maxKay])
                        {
                            if (allAreas.Contains(item))
                            {
                                allAreas.Remove(item);
                            }
                        }
                    }

                    //将max指针置空
                    maxKay = null;
                }

                
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
