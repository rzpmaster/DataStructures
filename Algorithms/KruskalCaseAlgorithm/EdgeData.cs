using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalCaseAlgorithm
{
    public class EdgeData:IComparable<EdgeData>
    {
        public char start;
        public char end;
        public int weight;

        public EdgeData(char start,char end,int weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }

        public int CompareTo(EdgeData other)
        {
            if (this.weight>other.weight)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return string.Format("<{0}，{1}>\t权值为{2}", this.start, this.end, this.weight);
        }
    }
}
