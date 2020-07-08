using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    /// <summary>
    /// 递归
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //LabyrinthBacktracking labyrinthBacktracking = new LabyrinthBacktracking();
            //labyrinthBacktracking.Run();

            EightQueueQuestion eightQueueQuestion = new EightQueueQuestion();
            eightQueueQuestion.Check(0);
            Console.WriteLine("一共有"+ eightQueueQuestion.GetCount()+"种解法");
            Console.WriteLine("一共尝试了" + eightQueueQuestion.GetJudgeCount() + "次");

            Console.ReadKey();
        }
    }
}
