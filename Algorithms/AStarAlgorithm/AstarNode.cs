using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    /// <summary>
    /// 格子类
    /// </summary>
    class AstarNode
    {
        public AstarNode(int x, int y, NodeType nodeType)
        {
            this.x = x;
            this.y = y;
            this.nodeType = nodeType;
        }

        public double F
        {
            get { return g + h; }
        }
        public double G
        {
            get { return g; }
            set { g = value; }
        }
        public double H
        {
            get { return h; }
            set { h = value; }
        }
        public AstarNode PreNode
        {
            get { return preNode; }
            set { preNode = value; }
        }
        public NodeType NodeType
        {
            get { return nodeType; }
            set { nodeType = value; }
        }

        public static double GetManhattanDistance(AstarNode node1, AstarNode node2)
        {
            return Math.Abs(node1.x - node2.x) + Math.Abs(node1.y - node2.y);
        }


        //寻路消耗
        double g;
        double h;

        //前驱节点
        AstarNode preNode;

        //格子坐标
        public int x;
        public int y;

        //格子类型
        NodeType nodeType;
    }

    public enum NodeType
    {
        CanWalk,
        Obstacle
    }
}
