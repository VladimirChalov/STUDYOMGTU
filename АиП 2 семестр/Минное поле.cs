using System;
using System.Linq;

class MinefieldPathFinder
{
    static void Main()
    {
        Console.WriteLine("Введите размеры поля (N M):");
        var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        int[,] mineField = new int[rows, cols];

        Console.WriteLine($"Введите {rows} строк по {cols} чисел (количество мин в каждой зоне):");
        for (int i = 0; i < rows; i++)
        {
            var rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < cols; j++)
            {
                mineField[i, j] = rowValues[j];
            }
        }

        var optimalPath = FindOptimalPath(mineField, rows, cols);

        Console.WriteLine("\nОптимальный путь:");
        foreach (var position in optimalPath)
        {
            Console.WriteLine(position + 1);
        }
    }

    static int[] FindOptimalPath(int[,] field, int rows, int cols)
    {
        int[,] dp = new int[rows, cols];
        int[,] path = new int[rows, cols];

        for (int j = 0; j < cols; j++)
        {
            dp[0, j] = field[0, j];
            path[0, j] = -1;
        }

        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int minPrev = int.MaxValue;
                int bestCol = -1;

                for (int k = Math.Max(0, j - 1); k <= Math.Min(cols - 1, j + 1); k++)
                {
                    if (dp[i - 1, k] < minPrev)
                    {
                        minPrev = dp[i - 1, k];
                        bestCol = k;
                    }
                }

                dp[i, j] = field[i, j] + minPrev;
                path[i, j] = bestCol;
            }
        }

        int minCost = int.MaxValue;
        int endCol = 0;
        for (int j = 0; j < cols; j++)
        {
            if (dp[rows - 1, j] < minCost)
            {
                minCost = dp[rows - 1, j];
                endCol = j;
            }
        }

        int[] result = new int[rows];
        int currentCol = endCol;
        result[rows - 1] = currentCol;

        for (int i = rows - 2; i >= 0; i--)
        {
            currentCol = path[i + 1, currentCol];
            result[i] = currentCol;
        }

        return result;
    }
}
}