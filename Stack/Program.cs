using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// 栈
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region StackDemo
            //Stack<string> stack = new Stack<string>();
            //stack.Push("rzp");
            //stack.Push("zjy");
            //stack.Push("zwj");
            //stack.Push("zm");

            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}


            #endregion

            #region ArrayStack
            //ArrayStack stack = new ArrayStack(4);
            //stack.Push("rzp");
            //stack.Push("zjy");
            //stack.Push("zwj");
            //stack.Push("zm");
            //stack.Push("zm");
            //stack.Pop();
            //stack.Pop();

            //stack.ShowList();

            #endregion

            #region LinkedListStack
            //LinkedListStack stack = new LinkedListStack(4);

            //HeroNode hero1 = new HeroNode(1, "宋江", "及时雨");
            //HeroNode hero2 = new HeroNode(2, "卢俊义", "玉麒麟");
            //HeroNode hero3 = new HeroNode(3, "吴用", "智多星");
            //HeroNode hero4 = new HeroNode(4, "林冲", "豹子头");
            //stack.Push(hero1);
            //stack.Push(hero2);
            //stack.Push(hero3);
            //stack.Push(hero4);
            //stack.Push(hero4);
            ////stack.Pop();
            ////stack.Pop();
            //stack.ShowList();
            #endregion

            #region Calculater
            //string expression = "70+20*6-4";
            //Calculater calc = new Calculater(expression);
            //calc.Run();
            #endregion

            #region PolandNotationCalc
            //定义一个逆波兰表达式
            //(3+4)*5-6 => "3 4 + 5 * 6 -"
            //string suffixExpression = "3 4 + 5 * 6 -";//为了方便，用空格隔开
            //4*5-8+60+8/2
            //string suffixExpression = "4 5 * 8 - 60 + 8 2 / +";//76
            //PolandNotation polandNotation = new PolandNotation(suffixExpression);
            //polandNotation.Run();

            //完整版功能
            string expression = "1+((2+3)*4)-5";
            PolandNotation polandNotation = new PolandNotation(expression);
            //var list= polandNotation.ParseSuffixExpressionList();
            polandNotation.Run();
            #endregion

            Console.ReadKey(); 
        }
    }
}
