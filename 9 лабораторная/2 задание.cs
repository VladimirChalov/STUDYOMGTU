using System;

namespace Omgtu
{
    class Program
    {
        public static void Main()
        {
            string example = "abcabcabcabcabcabc";
            int length = 3;
            int maxLength = 0;
            Console.WriteLine("Введите строку: ");
            string input = Convert.ToString(Console.ReadLine());
            string temp = input.Substring(0, length);

            while (length <= input.Length)
            {
                temp = input.Substring(0, length);
                if (example.Contains(temp))
                {
                    length += 1;
                    if (length == input.Length + 1)
                    {
                        if (maxLength < length - 1)
                        {
                            maxLength = length - 1;
                        }
                        break;
                    }
                }
                else
                {
                    if (length == 3)
                    {
                        maxLength = 0;
                    }
                    else if (maxLength < length - 1)
                    {
                        maxLength = length - 1;
                    }
                    input = input.Substring(length - 1);
                    length = 3;
                }
            }
            Console.WriteLine("Максимальная длина: " + maxLength);
        }
    }
}

