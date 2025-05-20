using System;

class Program
{
    static unsafe void Main()
    {
        Console.WriteLine("Введите размер: ");
        int arraySize = int.Parse(Console.ReadLine());
        int* numbersPtr = stackalloc int[arraySize];

        Console.WriteLine($"Введите {arraySize} чисел: ");
        for (int index = 0; index < arraySize; index++)
        {
            int userNumber = int.Parse(Console.ReadLine());
            numbersPtr[index] = userNumber;
        }

        for (int index = 0; index < arraySize; index++)
        {
            if (IsPalindrome(numbersPtr[index]))
            {
                Console.WriteLine($"{numbersPtr[index]} - палиндром");
            }
        }
    }

    static bool IsPalindrome(int number)
    {
        string numberString = number.ToString();
        for (int charIndex = 0; charIndex < numberString.Length / 2; charIndex++)
        {
            if (numberString[charIndex] != numberString[numberString.Length - charIndex - 1])
            {
                return false;
            }
        }
        return true;
    }
}