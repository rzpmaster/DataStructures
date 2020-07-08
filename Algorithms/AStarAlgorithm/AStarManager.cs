using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class AStarManager
    {
        private AStarManager()
        {
            openList = new List<AstarNode>();
            closeList = new List<AstarNode>();
        }

        public static AStarManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AStarManager();
                }
                return instance;
            }
        }

        public void InitMap(int[,] map)
        {
            this.mapWidth = map.GetLength(0);
            this.mapHeight = map.GetLength(1);
            nodes = new AstarNode[mapWidth, mapHeight];

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    AstarNode node = new AstarNode(i, j, map[i, j] == 0 ? NodeType.CanWalk : NodeType.Obstacle);
                    nodes[i, j] = node;
                }
            }
        }

        public List<AstarNode> FindPath(Vector2 startPoint, Vector2 endPoint)
        {
            if (!IsPointInMap(startPoint) || !IsPointInMap(endPoint))
            {
                Console.WriteLine("起终点不在地图内");
                return null;
            }

            this.start = nodes[(int)startPoint.X, (int)startPoint.Y];
            this.end = nodes[(int)endPoint.X, (int)endPoint.Y];
            if (start.NodeType == NodeType.Obstacle || end.NodeType == NodeType.Obstacle)
            {
                Console.WriteLine("起终点是障碍物");
                return null;
            }

            //清空列表
            closeList.Clear();
            openList.Clear();

            start.PreNode = null;
            start.G = 0;
            start.H = 0;

            closeList.Add(start);

            //开始计算
            var currNode = start;
            while (true)
            {
                //8个方向
                //x-1,y+1
                FindNearlyNodeToOpenList(currNode.x - 1, currNode.y + 1, 1.4, currNode);
                //x,y+1
                FindNearlyNodeToOpenList(currNode.x, currNode.y + 1, 1, currNode);
                // x+1,y+1
                FindNearlyNodeToOpenList(currNode.x + 1, currNode.y + 1, 1.4, currNode);
                //x-1,y
                FindNearlyNodeToOpenList(currNode.x - 1, currNode.y, 1, currNode);
                //x+1,y
                FindNearlyNodeToOpenList(currNode.x + 1, currNode.y, 1, currNode);
                //x-1,y-1
                FindNearlyNodeToOpenList(currNode.x - 1, currNode.y - 1, 1.4, currNode);
                //x,y-1
                FindNearlyNodeToOpenList(currNode.x, currNode.y - 1, 1, currNode);
                //x+1,y-1
                FindNearlyNodeToOpenList(currNode.x + 1, currNode.y - 1, 1.4, currNode);

                //思路判断
                if (openList.Count==0)
                {
                    Console.WriteLine("死路");
                    return null;
                }

                //排序 找到最小的 继续循环 直到找到终点
                openList.Sort((a, b) =>
                {
                    if (a.F > b.F)
                    {
                        return 1;
                    }
                    else if (a.F == b.F)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                });

                closeList.Add(openList[0]);

                currNode = openList[0];
                openList.RemoveAt(0);

                if (currNode == end)
                {
                    List<AstarNode> path = new List<AstarNode>();
                    path.Add(currNode);
                    while (currNode.PreNode!=null)
                    {
                        path.Add(currNode.PreNode);
                        currNode = currNode.PreNode;
                    }
                    path.Reverse();
                    return path;
                } 
            }

        }

        private void FindNearlyNodeToOpenList(int x, int y, double g, AstarNode preNode)
        {
            if (!IsPointInMap(x, y))
            {
                return;
            }

            AstarNode tempNode = nodes[x, y];
            if (tempNode == null || tempNode.NodeType == NodeType.Obstacle||
                closeList.Contains(tempNode))
            {
                return;
            }

            if (openList.Contains(tempNode))
            {
                //修正g 及前驱节点
                var gOld = tempNode.G;
                var gNew = preNode.G + g;

                if (gNew < gOld)
                {
                    tempNode.PreNode = preNode;
                    tempNode.G = preNode.G + g;
                    tempNode.H = AstarNode.GetManhattanDistance(tempNode, end);
                    //openList.Add(tempNode);//已经在openList中了
                    return;
                }
                else
                {
                    //不需要修正，保留
                    return;
                }

                //return;
            }
            else
            {
                tempNode.PreNode = preNode;
                tempNode.G = preNode.G + g;
                //启发函数
                tempNode.H = AstarNode.GetManhattanDistance(tempNode, end);
                openList.Add(tempNode);
            }
        }

        private bool IsPointInMap(Vector2 point)
        {
            return IsPointInMap((int)point.X, (int)point.Y);
        }

        private bool IsPointInMap(int x, int y)
        {
            if (x < 0 || x >= mapWidth ||
                y < 0 || y >= mapHeight)
            {
                return false;
            }
            return true;
        }

        static AStarManager instance;

        AstarNode[,] nodes;
        List<AstarNode> openList;
        List<AstarNode> closeList;

        AstarNode start;
        AstarNode end;


        int mapHeight;
        int mapWidth;
    }
}
