using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "()";
            var data = IsValid(s);
            Console.WriteLine(data);


        }
        public static bool IsValid(string s)
        {
            var charString = s.ToCharArray();
            var stack = new Stack<char>();
            if (charString.Length % 2 != 0)
            {
                return false;
            }

            foreach (var item in charString)
            {
                //"([]{})";
                if (item == '(')
                {
                    stack.Push(')');
                }
                else if (item == '{')
                {
                    stack.Push('}');
                }
                else if (item == '[')
                {
                    stack.Push(']');
                }
                else if ( stack.Count == 0 || stack.Pop() != item)
                {
                    return false;
                }

            }

            return stack.Count == 0;
        }
    }
}