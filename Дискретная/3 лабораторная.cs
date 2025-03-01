using System;
namespace Omgtu
{
    class Program
    {
        static void Main()
        {
            int[,] graph = new int[,]
            {
            { 0, 400, 0, 0, 511 },
            { 600, 0, 155, 0, 200 },
            { 0, 101, 0, 409, 0 },
            { 0, 0, 444, 0, 800 },
            { 505, 212, 0, 334, 0 }
            };

            Console.Write("Введите начальную вершину (0-4): ");
            int start = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите конечную вершину (0-4): ");
            int end = Convert.ToInt32(Console.ReadLine());

            Dijkstra(graph, start, end);
        }

        static void Dijkstra(int[,] graph, int startVertex, int endVertex)
        {
            int V = graph.GetLength(0);
            int[] distances = new int[V];
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                distances[i] = int.MaxValue;
                visited[i] = false;
            }

            distances[startVertex] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = FindMinDistanceVertex(distances, visited, V);
                visited[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !visited[v] && distances[u] != int.MaxValue && distances[u] + graph[u, v] < distances[v])
                    {
                        distances[v] = distances[u] + graph[u, v];
                    }
                }
            }

            Console.WriteLine($"Минимальное расстояние от вершины {startVertex} до вершины {endVertex}: {distances[endVertex]}");
        }

        static int FindMinDistanceVertex(int[] distances, bool[] visited, int V)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && distances[v] <= minValue)
                {
                    minValue = distances[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}

