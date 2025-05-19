using System;
using System.Collections.Generic;

class Program
{
    static void PoleDraw(int[,] pole)
    {
        int rows = pole.GetLength(0);
        int cols = pole.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (pole[i, j] == int.MaxValue)
                {
                    Console.Write(" -- ");
                }
                else if (pole[i, j] == -1)
                {
                    Console.Write(" ## ");
                }
                else
                {
                    Console.Write($"{pole[i, j],3} ");
                }
            }
            Console.WriteLine();
        }
    }

    static void Volnoloi(int[,] pole, int[] start, int[] end)
    {
        int rowsN = pole.GetLength(0);
        int colsN = pole.GetLength(1);
        int[][] move = new int[][]
        {
            new int[] { -1, 0 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { 0, 1 }
        };

        int[,] distances = new int[rowsN, colsN];
        for (int i = 0; i < rowsN; i++)
            for (int j = 0; j < colsN; j++)
                distances[i, j] = int.MaxValue;

        distances[start[0], start[1]] = 0;
        var waveFront = new List<int[]> { start };

        int currentDistance = 0;
        bool found = false;

        while (waveFront.Count > 0 && !found)
        {
            currentDistance++;
            var newWaveFront = new List<int[]>();

            foreach (var pos in waveFront)
            {
                foreach (var d in move)
                {
                    int newX = pos[0] + d[0];
                    int newY = pos[1] + d[1];

                    if (newX >= 0 && newY >= 0 && newX < rowsN && newY < colsN)
                    {
                        if (pole[newX, newY] == 0 && distances[newX, newY] == int.MaxValue)
                        {
                            distances[newX, newY] = currentDistance;
                            newWaveFront.Add(new int[] { newX, newY });

                            if (newX == end[0] && newY == end[1])
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                }
                if (found) break;
            }

            waveFront = newWaveFront;
        }

        Console.WriteLine("Матрица расстояний:");
        PoleDraw(distances);
    }

    static void Main()
    {
        int[,] pole = new int[,]
        {
            { 0, -1, 0, 0, 0, -1, 0, 0, 0, 0 },
            { 0, -1, 0, -1, 0, -1, 0, -1, 0, 0 },
            { 0, 0, 0, -1, 0, 0, 0, -1, 0, -1 },
            { -1, -1, 0, -1, -1, -1, 0, -1, 0, 0 },
            { 0, 0, 0, 0, 0, -1, 0, -1, -1, 0 },
            { 0, -1, -1, -1, 0, -1, 0, 0, 0, 0 },
            { 0, -1, 0, 0, 0, -1, -1, -1, 0, 0 },
            { 0, -1, 0, -1, -1, -1, 0, 0, 0, 0 },
            { 0, 0, 0, -1, 0, 0, 0, -1, 0, 0 },
            { 0, -1, -1, -1, 0, -1, 0, 0, 0, 0 }
        };

        int[] start = new int[] { 0, 0 };
        int[] end = new int[] { 9, 9 };

        Console.WriteLine("Исходный лабиринт:");
        PoleDraw(pole);
        Console.WriteLine($"\nСтарт: [{start[0]},{start[1]}], Финиш: [{end[0]},{end[1]}]");

        Volnoloi(pole, start, end);
    }
}













