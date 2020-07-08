using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm
{
    public class GraphMap
    {
        public int Verxs { private set; get; }
        public char[] Data { set; get; }
        public int[,] Weight { set; get; }

        public GraphMap(int verxs)
        {
            this.Verxs = verxs;
            Data = new char[verxs];
            Weight = new int[verxs, verxs];
        }
    }
}
