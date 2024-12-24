using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            string g = "";
            Regex regex = new Regex(@"a.b");
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                g += Convert.ToString(match).Substring(1, 1);
            }

            char mostFrequentChar = FindMostFrequentChar(g);
            Console.WriteLine($"Самый часто повторяющийся символ в паттерне: {mostFrequentChar}");
        }

        static char FindMostFrequentChar(string str)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            char mostFrequentChar = str[0];
            int maxCount = 0;

            foreach (var kvp in charCount)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostFrequentChar = kvp.Key;
                }
            }
            return mostFrequentChar;
        }
    }
}
