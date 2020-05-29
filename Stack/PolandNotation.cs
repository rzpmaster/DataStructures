using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// 后缀表达式计算器（逆波兰表达式）
    /// </summary>
    public class PolandNotation
    {
        private string expression;

        public PolandNotation(string expression)
        {
            this.expression = expression;
        }

        //public List<string> GetList()
        //{
        //    var split = suffixExpression.Split(' ');
        //    List<string> list = new List<string>();
        //    foreach (var item in split)
        //    {
        //        list.Add(item);
        //    }
        //    return list;
        //}

        public void Run()
        {
            var list = ParseSuffixExpressionList();
            Stack<string> stack = new Stack<string>();
            string pattern = @"[0-9]+";
            foreach (var item in list)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(item, pattern))
                {
                    //入栈
                    stack.Push(item);
                }
                else
                {
                    //pop两个数计算，在入栈
                    int num2 = Convert.ToInt32(stack.Pop());
                    int num1 = Convert.ToInt32(stack.Pop());
                    int res = 0;
                    if (item.Equals("+"))
                    {
                        res = num1 + num2;
                    }
                    else if (item.Equals("-"))
                    {
                        res = num1 - num2;
                    }
                    else if (item.Equals("*"))
                    {
                        res = num1 * num2;
                    }
                    else if (item.Equals("/"))
                    {
                        res = num1 / num2;
                    }
                    else
                    {
                        throw new Exception("运算符有误");
                    }

                    //入栈
                    stack.Push(res.ToString());
                }
            }
            //最后留在栈中的，就是计算结果
            string rst = stack.Pop();
            Console.WriteLine("计算结果为"+ rst);
        }

        
        public List<string> ParseSuffixExpressionList()
        {
            Stack<string> s1 = new Stack<string>();
            List<string> s2 = new List<string>();//没有pop操作，直接用list代替

            string pattern = @"[0-9]+";

            var ls = ConvertToInfixExpressionList();
            foreach (var item in ls)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(item, pattern))
                {
                    //如果是一个数，就入栈s2
                    s2.Add(item);
                }
                else if (item.Equals("("))
                {
                    s1.Push(item);
                }
                else if (item.Equals(")"))
                {
                    //如果是右括号，则弹出s1栈顶的运算符，并压入s2，直到遇到左括号为止，并将左括号pop掉
                    while (!s1.Peek().Equals("("))
                    {
                        s2.Add(s1.Pop());
                    }
                    s1.Pop();//弹出（
                }
                else
                {
                    //如果走到这里，说明是符号

                    //如果item的优先级大于s1栈顶符号的优先级，直接压入s1
                    //如果item的优先级小于等于s1栈顶符号的优先级，将s1栈顶的符号弹出，压入s2
                    //继续比较，直到栈空

                    while (s1.Count!=0&&Operation.GetValue(item)<=Operation.GetValue(s1.Peek()))
                    {
                        s2.Add(s1.Pop());
                    }
                    //还要将item压入栈s1
                    s1.Push(item);
                }
            }

            //将s1中的运算符依次弹出，压入s2
            while (s1.Count != 0)
            {
                s2.Add(s1.Pop());
            }

            return s2;
        }


        /// <summary>
        /// 将中缀表达式转为List
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private List<string> ConvertToInfixExpressionList()
        {
            //将中缀表达式转化为list，方便遍历
            List<string> result = new List<string>();
            foreach (var item in expression.ToCharArray())
            {
                result.Add(item.ToString());
            }
            return result;
        }
    }

    public class Operation
    {
        private static int add = 1;
        private static int sub = 1;
        private static int mul = 2;
        private static int div = 2;
        private static int leftBracket = 0;

        //返回运算符的优先级数字
        public static int GetValue(String operation)
        {
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = add;
                    break;
                case "-":
                    result = sub;
                    break;
                case "*":
                    result = mul;
                    break;
                case "/":
                    result = div;
                    break;
                case "(":
                    result = leftBracket;
                    break;
                default:
                    throw new Exception("运算符不支持");
            }

            return result;
        }
    }
}
