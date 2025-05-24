using System;
using System.Collections.Generic;

class MaxEmptyRectangleFinder
{
    static void Main()
    {
        Console.WriteLine("Введите размеры области (N M):");
        var dimensions = Console.ReadLine().Split();
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);

        Console.WriteLine("Введите количество закрашенных клеток (K):");
        int k = int.Parse(Console.ReadLine());

        bool[,] filled = new bool[height, width];

        Console.WriteLine($"Введите координаты {k} закрашенных клеток (X Y):");
        for (int i = 0; i < k; i++)
        {
            var coords = Console.ReadLine().Split();
            int x = int.Parse(coords[0]) - 1;
            int y = int.Parse(coords[1]) - 1;
            if (x >= 0 && x < width && y >= 0 && y < height)
                filled[y, x] = true;
        }

        int maxArea = FindMaxEmptyRectangle(filled, height, width);
        Console.WriteLine($"Максимальная площадь свободного прямоугольника: {maxArea}");
    }

    static int FindMaxEmptyRectangle(bool[,] filled, int rows, int cols)
    {
        int[] heights = new int[cols];
        int maxArea = 0;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                heights[col] = filled[row, col] ? 0 : (heights[col] + 1);
            }


            for (int col = 0; col < cols; col++)
            {
                if (filled[row, col]) continue;

                int minHeight = heights[col];
                int currentArea = minHeight;

                for (int right = col + 1; right < cols && !filled[row, right]; right++)
                {
                    minHeight = Math.Min(minHeight, heights[right]);
                    currentArea = Math.Max(currentArea, minHeight * (right - col + 1));
                }

                maxArea = Math.Max(maxArea, currentArea);
            }
        }

        return maxArea;
    }
}