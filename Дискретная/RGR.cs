using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите (кол-во зданий)(пробел)(кол-во дорог)");
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        int[,] dist = new int[N + 1, N + 1];
        const int INF = int.MaxValue / 2;

        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                dist[i, j] = (i == j) ? 0 : INF;
            }
        }

        for (int i = 0; i < M; i++)
        {
            Console.WriteLine("Введите (номер здания)(пробел)(номер здания)(пробел)(длина дороги)");
            input = Console.ReadLine().Split();
            int s = int.Parse(input[0]);
            int e = int.Parse(input[1]);
            int l = int.Parse(input[2]);

            if (l < dist[s, e])
            {
                dist[s, e] = l;
                dist[e, s] = l;
            }
        }

        // Алгоритм Флойда
        for (int k = 1; k <= N; k++)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        int minMaxDist = int.MaxValue;
        int result = 1;
        for (int i = 1; i <= N; i++)
        {
            int currentMax = 0;
            for (int j = 1; j <= N; j++)
            {
                if (dist[i, j] > currentMax)
                {
                    currentMax = dist[i, j];
                }
            }

            if (currentMax < minMaxDist)
            {
                minMaxDist = currentMax;
                result = i;
            }
        }
        Console.Write("Столовая будет находиться в здании номер:");
        Console.WriteLine(result);
    }
}