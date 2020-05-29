using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// 中缀表达式计算器
    /// </summary>
    class Calculater
    {
        private string expression;

        public Calculater(string expression)
        {
            this.expression = expression;
        }

        public int Priority(int oper)
        {
            if (oper=='*'||oper=='/')
            {
                return 1;
            }
            else if (oper=='+'||oper=='-')
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }


        public bool IsOper(char oper)
        {
            return oper == '+' || oper == '-' || oper == '*' || oper == '/';
        }

        public int Calc(int num1,int num2,int oper)
        {
            int res = 0;
            switch (oper)
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num2 - num1;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                case '/':
                    res = num2 / num1;
                    break;
                default:
                    break;
            }
            return res;
        }

        internal void Run()
        {
            ArrayStack numStack = new ArrayStack(10);
            ArrayStack operStack = new ArrayStack(10);

            int index = 0;//指针
            int num1, num2, oper, res;
            char ch;
            string keepNum = "";

            while (true)
            {
                //扫描每一个字符
                ch = expression.Substring(index, 1).ToCharArray()[0];
                if (IsOper(ch))
                {
                    //判断当前符号栈是否为空
                    if (!operStack.IsEmpty())
                    {
                        if (Priority(ch) <= Priority(operStack.Peek()))
                        {
                            //从数栈中pop两个数，从符号栈中pop出一个符号，计算；
                            //将计算结果放入数栈，将当前符号栈如栈
                            num1 = numStack.Pop();
                            num2 = numStack.Pop();
                            oper = operStack.Pop();
                            res = Calc(num1, num2, oper);
                            numStack.Push(res);
                            operStack.Push(ch);
                        }
                        else
                        {
                            //入栈
                            operStack.Push(ch);
                        }
                    }
                    else
                    {
                        //为空直接入栈
                        operStack.Push(ch);
                    }
                }
                else
                {
                    //如果是数字，直接入栈
                    //numStack.Push(ch-48);
                    //如果是多位数的话，不能直接入栈

                    keepNum += ch;//先不着急入栈，先存一下
                    if (index == expression.Length - 1)
                    {
                        //如果ch已经是最后一个了，就不要往后看了
                        numStack.Push(ch - 48);
                    }
                    else
                    {
                        //继续扫描，往后看一位，直到后面的是运算符，拼接后入栈
                        if (IsOper(expression.Substring(index + 1, 1).ToCharArray()[0]))
                        {
                            //如果后一位是运算符，入栈
                            numStack.Push(Convert.ToInt32(keepNum));
                            keepNum = "";
                        }
                    }

                }
                index++;
                if (index >= expression.Length)
                {
                    break;
                }
            }

            //扫描完后，依次弹出计算
            while (true)
            {
                //如果符号栈为空，数栈中的就是结果
                if (operStack.IsEmpty())
                {
                    break;
                }
                num1 = numStack.Pop();
                num2 = numStack.Pop();
                oper = operStack.Pop();
                res = Calc(num1, num2, oper);
                numStack.Push(res);
            }

            res = numStack.Pop();

            Console.WriteLine("计算结果为" + res.ToString());
        }
    }
}
