using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _SPOJ_Infix2RPN
{
    class Program
    {
        //http://www.spoj.pl/problems/ONP/
        static void Main(string[] args)
        {
            int it = int.Parse(Console.ReadLine());
            while (it > 0)
            {
                Console.WriteLine(Infix2RPN(Console.ReadLine()));
                it--;
            }

        }

        static string Infix2RPN(string exp)
        {
            StringBuilder rpn = new StringBuilder();
            Stack<char> st = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                char c;
                switch (exp[i])
                {
                    #region Letter
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        rpn.Append(exp[i]);
                        break;
                    #endregion
                    case '(':
                        st.Push('(');
                        break;
                    case ')':
                        try
                        {
                            c = st.Pop();
                            while (c != '(')
                            {
                                rpn.Append(c);
                                c = st.Pop();
                            }
                        }
                        catch (Exception)
                        {
                            return "Unbalanced Parenthesis";
                        }
                        break;
                    case '+':
                    case '-':
                        c = st.Pop();

                        while (c == '^' || c == '*' || c == '/')
                        {
                            rpn.Append(c);
                            c = st.Pop();
                        }

                        st.Push(c);
                        st.Push(exp[i]);
                        break;
                    case '*':
                    case '/':
                        c = st.Pop();

                        while (c == '^')
                        {
                            rpn.Append(c);
                            c = st.Pop();
                        }

                        st.Push(c);
                        st.Push(exp[i]);
                        break;
                    case '^':
                        st.Push('^');
                        break;
                }
            }
            return rpn.ToString();
        }

    }
}
