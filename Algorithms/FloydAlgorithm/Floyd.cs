using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlgorithm
{
    public class Floyd
    {
        private char[] vertex;
        private int[,] dis;//距离表
        private int[,] pre;//前驱顶点表

        public Floyd(int length,int[,] matrix,char[] vertex)
        {
            this.vertex = vertex;
            this.dis = matrix;
            this.pre = new int[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    pre[i, j] = i;
                }
            }
        }

        //弗洛伊德算法
        public void FloydAlgorithm()
        {
            int len = 0;//保存变量距离

            //遍历中间顶点
            for (int k = 0; k < dis.GetLength(0); k++)//k是中间顶点
            {
                for (int i = 0; i < dis.GetLength(0); i++)//从i顶点出发
                {
                    for (int j = 0; j < dis.GetLength(0); j++)//到达j顶点
                    {
                        len = dis[i, k] + dis[k, j];
                        if (len<dis[i,j])
                        {//更新距离表和前驱顶点表
                            dis[i, j] = len;
                            pre[i, j] = pre[k, j];
                        }
                    }
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("距离表");
            Show(dis,1);
            Console.WriteLine();
            Console.WriteLine("前驱表");
            Show(pre,0);
        }

        private void Show(int[,] data,int mode)
        {
            char[] vertex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

            for (int i = 0; i < dis.GetLength(0); i++)
            {
                for (int j = 0; j < dis.GetLength(0); j++)
                {
                    if (mode==0)
                    {
                        Console.Write(vertex[data[i, j]] + "\t");
                    }
                    else
                    {
                        Console.Write(string.Format("{0,-13}", "(" + vertex[i] + "," + vertex[j] + ")" + data[i, j]));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
