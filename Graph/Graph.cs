using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private List<string> vertexList;    //储存顶点集合
        private int[,] edges;               //储存图对应的邻接矩阵
        private int numOfEdges;             //储存边的个数

        private bool[] isVisited;//标记遍历时是否被访问过

        public Graph(int n)
        {
            edges = new int[n, n];
            vertexList = new List<string>(n);
            isVisited = new bool[n];
            numOfEdges = 0;
        }

        //插入节点
        public void InsertVertex(string vertex)
        {
            vertexList.Add(vertex);
        }

        //添加边
        public void InsertEdge(int v1, int v2, int weight)
        {
            edges[v1, v2] = weight;
            edges[v2, v1] = weight;
            numOfEdges++;
        }

        //
        //常用方法
        //

        //返回节点个数
        public int GetNumOfVertex()
        {
            return vertexList.Count;
        }

        //返回边的个数
        public int GetNumOfEdge()
        {
            return numOfEdges;
        }

        //返回节点下表对应的数据
        public string GetValueByIndex(int n)
        {
            return vertexList[n];
        }

        //返回v1 v2之间的权值
        public int GetWeight(int v1, int v2)
        {
            return edges[v1, v2];
        }

        //显示图对应的矩阵
        public void ShowGraph()
        {
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                for (int j = 0; j < edges.GetLength(1); j++)
                {
                    Console.Write(edges[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        //
        //遍历
        //

        //得到第一个邻接节点的下表
        public int GetFirstNeighbor(int index)
        {
            for (int i = 0; i < vertexList.Count; i++)
            {
                if (edges[index, i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //根据前一个邻接节点的下标，获取下一个邻接节点
        public int GetNextNeighbor(int v1, int v2)
        {
            for (int i = v2 + 1; i < vertexList.Count; i++)
            {
                if (edges[v1, i] > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //深度优先遍历
        public void DFSShow()
        {
            for (int i = 0; i < GetNumOfVertex(); i++)
            {
                if (!isVisited[i])
                {
                    DFSShow(i);
                }
            }
        }

        private void DFSShow(int i)
        {
            //访问该节点
            Console.Write(GetValueByIndex(i) + "->");
            isVisited[i] = true;
            int w = GetFirstNeighbor(i);

            while (w != -1)//找到了
            {
                if (!isVisited[w])
                {
                    DFSShow(w);
                }
                //如果已经访问过了
                w = GetNextNeighbor(i, w);
            }
        }

        
    }
}
