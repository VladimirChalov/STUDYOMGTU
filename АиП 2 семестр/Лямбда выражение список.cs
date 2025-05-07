using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        List<string> slova = new List<string> { "панда", "яблоко", "птица", "машина", "пельмени", "дом", "планета" };

        List<string> otobrannieSlova = slova.Where(slovo => slovo.StartsWith("п")).ToList();

        Console.WriteLine("Слова, начинающиеся на букву 'п':");
        foreach (var slovo in otobrannieSlova)
        {
            Console.WriteLine(slovo);
        }
    }
}
