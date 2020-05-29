using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    /// <summary>
    /// 队列 环形队列
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue queue = new ArrayQueue(3);

            CircleArrayQueue circularArray = new CircleArrayQueue(3);
        }
    }
}
