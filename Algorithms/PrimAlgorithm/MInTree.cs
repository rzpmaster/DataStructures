using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm
{
    public class MinTree
    {
        //prim核心算法
        //v表示从图的第几个顶点开始
        public void Prim(GraphMap graph, int v)
        {
            int[] visited = new int[graph.Verxs];//标记顶点是否被访问过

            visited[v] = 1;//标记当前顶点为访问过
            
            for (int k = 1; k < graph.Verxs; k++)//普利姆算法结束后，有n-1条边
            {
                int h1 = -1, h2 = -1;//h1 h2 记录两个顶点的下标
                int minWeight = 10000;//记录边的最小权值

                for (int i = 0; i < graph.Verxs; i++)
                {
                    for (int j = 0; j < graph.Verxs; j++)
                    {
                        if (visited[i] == 1 && visited[j] == 0 &&
                            graph.Weight[i, j] < minWeight)
                        {
                            minWeight = graph.Weight[i, j];//记录最小边的权值
                            h1 = i;//记录最小边的顶点下标
                            h2 = j;
                        }
                    }
                }

                //找权值最小的边了
                Console.WriteLine(string.Format("边<{0},{1}>\t权值为{2}",graph.Data[h1],graph.Data[h2],minWeight));

                //将当前访问过的顶点标记为访问过
                visited[h2] = 1;
            }
        }

        public void CreateGraph(GraphMap graph, int verxs, char[] data, int[,] weight)
        {
            for (int i = 0; i < verxs; i++)
            {
                graph.Data[i] = data[i];
                for (int j = 0; j < verxs; j++)
                {
                    graph.Weight[i, j] = weight[i, j];
                }
            }
        }

        public void ShowGraph(GraphMap graph)
        {
            for (int i = 0; i < graph.Verxs; i++)
            {
                for (int j = 0; j < graph.Verxs; j++)
                {
                    Console.Write(graph.Weight[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
