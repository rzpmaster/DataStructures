using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    /// <summary>
    /// 迷宫回溯
    /// </summary>
    class LabyrinthBacktracking
    {
        private int[,] map;
        public LabyrinthBacktracking()
        {
            map = CreateMap();
        }

        public void Run()
        {
            //输出地图
            Console.WriteLine("当前初始地图为");
            ShowMap();
            Console.WriteLine();
            if(SetWays(1, 1))
            {
                Console.WriteLine("标识过的地图为");
                ShowMap();
            }
        }

        /// <summary>
        /// 找到通路返回True，否则返回False
        /// </summary>
        /// <param name="i">出发行</param>
        /// <param name="j">出发列</param>
        /// <returns></returns>
        /// <remarks>
        /// 开始点（1，1），结束点（6，5）
        /// 当地图点是0时，表示还没测试过，当为1是为墙，为2时表示通路，可以走
        /// 为3时，表示已经走过，但是走不通
        /// 策略：先走下面，下->右->上->左，如果走不通，再回溯
        /// </remarks>
        private bool SetWays(int i,int j)
        {
            if (map[6,5]==2)
            {
                return true;
            }
            else
            {
                if (map[i,j]==0)//这个点没走过
                {
                    map[i, j] = 2;//假定该点能走通
                    if (SetWays(i+1,j))//向下走
                    {
                        return true;
                    }
                    else if (SetWays(i,j+1))//向右走
                    {
                        return true;
                    }
                    else if (SetWays(i-1,j))//向上走
                    {
                        return true;
                    }
                    else if (SetWays(i,j-1))//向走左
                    {
                        return true;
                    }
                    //死路，该点走不通
                    map[i, j] = 3;
                    return false;
                }
                else
                {
                    //不等于0，有可能是1，有可能是2，有可能是3
                    return false;
                }
            }
        }

        private void ShowMap()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private int[,] CreateMap()
        {
            int[,] map = new int[8, 7];
            //使用1表示墙

            //把上下置为1
            for (int i = 0; i < 7; i++)
            {
                map[0, i] = 1;
                map[7, i] = 1;
            }
            //把左右置为1
            for (int i = 0; i < 8; i++)
            {
                map[i, 0] = 1;
                map[i, 6] = 1;
            }
            //设置挡板
            map[3, 1] = 1;
            map[3, 2] = 1;

            return map;
        }
    }
}
