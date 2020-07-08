using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalCaseAlgorithm
{
    public class KruskalCase
    {
        private int edgeNum;    //边的个数
        private char[] vertexs; //顶点数组
        private int[,] matrix;  //邻接矩阵

        //private const int INF = int.MaxValue;
        private const int INF = 10000;

        public KruskalCase(char[] vertexs,int[,] matrix)
        {
            int vLen = vertexs.Length;

            this.vertexs = new char[vLen];
            for (int i = 0; i < vLen; i++)
            {
                this.vertexs[i] = vertexs[i];
            }

            this.matrix = new int[vLen, vLen];
            for (int i = 0; i < vLen; i++)
            {
                for (int j = 0; j < vLen; j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < vLen; i++)
            {
                for (int j = i+1; j < vLen; j++)
                {
                    if (this.matrix[i, j] != INF)
                    {
                        edgeNum++;
                    }
                }
            }
        }

        //克鲁斯卡尔算法
        public void Kruskal()
        {
            int index = 0;  //结果数组索引
            int[] ends = new int[edgeNum];  //记录 已有最小生成树 的每个顶点的终点

            //结果数组
            EdgeData[] rets = new EdgeData[edgeNum];

            //原始图中所有边的集合
            EdgeData[] edges = GetEdges();//已经按权重排序了

            //遍历edge数组加入结果数组，判断是否构成回路
            for (int i = 0; i < edgeNum; i++)
            {
                //获取起点
                int p1 = GetPosition(edges[i].start);
                //获取终点
                int p2 = GetPosition(edges[i].end);

                //获取p1在已有最小生成树中的终点
                int m = GetEnd(ends, p1);
                //获取p2在已有最小生成树中的终点
                int n = GetEnd(ends, p2);

                //判断是否构成回路
                if (m!=n)
                {
                    ends[m] = n;//设置m 在已有最小生成树中的终点
                    rets[index++] = edges[i];//有一条边加入结果数组
                }
            }

            //输出rets数组
            Print(rets);
        }

        /// <summary>
        /// 返回给定的ch 的顶点对应的下标，如果找不到，就返回-1
        /// </summary>
        /// <param name="ch">顶点的值，比如'A'\'B'</param>
        /// <returns></returns>
        private int GetPosition(char ch)
        {
            for (int i = 0; i < vertexs.Length; i++)
            {
                if (vertexs[i]==ch)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取图中的边放到 EdgeData[]中，后面要遍历该数组
        /// </summary>
        /// <returns></returns>
        public EdgeData[] GetEdges()
        {
            int index = 0;
            EdgeData[] edgeDatas = new EdgeData[edgeNum];
            for (int i = 0; i < vertexs.Length; i++)
            {
                for (int j = i+1; j < vertexs.Length; j++)
                {
                    if (matrix[i,j]!=INF)
                    {
                        edgeDatas[index++] = new EdgeData(vertexs[i], vertexs[j], matrix[i, j]);
                    }
                }
            }
            var temp = edgeDatas.ToList();
            temp.Sort();
            return temp.ToArray();
        }

        /// <summary>
        /// 获取下标为i的顶点的终点（动态获取）
        /// </summary>
        /// <param name="ends">记录各个顶点的终点的数组，遍历过程中逐步形成</param>
        /// <param name="i"></param>
        /// <returns></returns>
        private int GetEnd(int[] ends,int i)
        {
            while (ends[i]!=0)
            {
                i = ends[i];
            }
            return i;
        }

        public void ShowGraph()
        {
            for (int i = 0; i < vertexs.Length; i++)
            {
                for (int j = 0; j < vertexs.Length; j++)
                {
                    Console.Write(matrix[i,j]+"\t");
                }
                Console.WriteLine();
            }
        }

        private void Print(EdgeData[] rets)
        {
            for (int i = 0; i < rets.Count(); i++)
            {
                if (rets[i] == null) continue;
                Console.WriteLine(rets[i].ToString());
            }
        }
    }
}
