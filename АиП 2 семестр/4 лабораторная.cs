using System;
namespace Omgtu
{
    class Program
    {
       static void Main()
        {
            Console.Write("Введите строку (элементы через пробел): ");

            string[] s = ("" + Console.ReadLine()).Split(" ");

            Stack<float> nums = new Stack<float>();

            foreach (string i in s)
            {
                if (float.TryParse(i, out float j))
                {
                    nums.Push(j);
                }
                else
                {
                    if (nums.Count <= 1)
                    {
                        Console.WriteLine("неверный ввод уравнения");
                        return;
                    }
                    float result = 0;
                    switch (i)
                    {
                        default: Console.WriteLine("неверный ввод уравнения"); break;
                        case "+":
                            result = nums.Pop() + nums.Pop();
                            break;
                        case "-":
                            result = -nums.Pop() + nums.Pop();
                            break;
                        case "*":
                            result = nums.Pop() * nums.Pop();
                            break;
                        case "/":
                            float a = nums.Pop();
                            float b = nums.Pop();
                            if (a == 0)
                            {
                                Console.WriteLine("неверный ввод уравнения");
                                return;
                            }
                            result = b / a;
                            break;
                    }

                    nums.Push(result);
                }

            }


            Console.WriteLine("Ответ: " + nums.Peek());
        }
    }
}
