
using System;
using System.Collections.Generic;
namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите последовательность скобок: ");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Скобки расставлены неправильно.");
                        break;
                    }

                    char open = stack.Pop();
                    if ((open == '(' && ch != ')') ||
                        (open == '[' && ch != ']') ||
                        (open == '{' && ch != '}'))
                    {
                        Console.WriteLine("Скобки расставлены неправильно.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Скобки расставлены правильно.");
                    }
                }
            }
        }
    }
}

