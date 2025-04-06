using System;

namespace Omgtu
{
    class Program
    {
        static int Floyd(int[,] graph, int a, int b)
        {
            int n = graph.GetLength(0);
            int[,] dist = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        dist[i, j] = 0;
                    else if (graph[i, j] == 0)
                        dist[i, j] = int.MaxValue;
                    else
                        dist[i, j] = graph[i, j];
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue && dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            return dist[a, b];
        }

        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
            { 0, 1, 4, 0 },
            { 1, 0, 2, 5 },
            { 4, 2, 0, 1 },
            { 0, 5, 1, 0 }
            };

            Console.WriteLine("Введите первую вершину:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вторую вершину:");
            int b = Convert.ToInt32(Console.ReadLine());

            int result = Floyd(graph, a, b);

            if (result == int.MaxValue)
            {
                Console.WriteLine("Нет пути между вершинами.");
            }
            else
            {
                Console.WriteLine($"Кратчайшее расстояние между вершинами {a} и {b}: {result}");
            }
        }
    }
}