using System;

namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество элементов массива:");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] array_string = new string[n];
            Console.WriteLine("Введите элементы массива:");

            for (int i = 0; i < array_string.Length; i++)
            {
                array_string[i] = Console.ReadLine();
            }
            int[] array = new int[array_string.Length];

            for (int i = 0; i < array_string.Length; i++)
            {
                array[i] = Convert.ToInt32(array_string[i]);
            }

            bool isUniformDecreasing = true;
            int difference = array[0] - array[1]; 
            for (int i = 1; i < (array.Length - 1); i++)
            {
                if (array[i] - array[i + 1] != difference)
                {
                    isUniformDecreasing = false;
                    break;
                }
            }

            bool allEven = true;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    allEven = false;
                    break;
                }
            }


            Console.WriteLine("Элементы массива:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("Характеристика массива:");
            if (isUniformDecreasing)
            {
                Console.WriteLine("Массив равномерно убывает");
            }
            else
            {
                Console.WriteLine("Массив не является равномерно убывающим");
            }

            if (allEven)
            {
                Console.WriteLine("Все элементы массива четные");
            }
            else
            {
                Console.WriteLine("В массиве не все элементы четны");
            }
        }
    }
}
